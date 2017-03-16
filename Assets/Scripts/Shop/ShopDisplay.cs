using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopDisplay : MonoBehaviour {

    //Shop opening
    [SerializeField]private GameObject _shopOpeningHUD;
    [SerializeField]private Text _shopOpeningText;
    private float _maxTimeTillOpening = 5;
    private float _timeTillOpening;
    private bool _shopIsOpen;

    public float TimeTillOpening
    {
        get { return _timeTillOpening; }
        set { _timeTillOpening = value; }
    }

    public float MaxTimeTilleOpening
    {
        get { return _maxTimeTillOpening; }
    }

    //Shop panel
    [SerializeField]private GameObject  _shopPanel;
    
    //Shop time variables
    [SerializeField]private float       _maxTimeToShop;
                    private float       _timeToShop;
                    private int         _playerToShop = 0;
    //Scripts
    private ShopPhaseTurns _shopTurns;
    private GetUpgradeCosts _upgradeCosts;
    private WaveController  _waveController;
    private PlayerCharacter _matchingPlayer;
    public  PlayerCharacter MatchingPlayer
    {
        get { return _matchingPlayer; }
        set { _matchingPlayer = value; }
    }
    public float TimeToShop
    {
        get { return _timeToShop; }
    }

	void Start () {
        _timeToShop = _maxTimeToShop;
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _shopTurns = GetComponent<ShopPhaseTurns>();
        _upgradeCosts = GetComponent<GetUpgradeCosts>();
        FindingNemo();
        _shopTurns.SetShopInputs();
    }

    void Update()
    {
        ShopPhase();
    }

    void ShopPhase()
    {
        if(!_waveController.IsCombatPhase){ //If its not the combat phase, shopping will begin

            ShopOpeningCountdown();
            if (_shopIsOpen)
            {
                _shopPanel.SetActive(true);//shows the shop panel
                _shopTurns.SetShopInputs();
                FindingNemo();
                ShopTurnTimer(); //Runs the timer
            }
        }
    }

    void ShopOpeningCountdown()
    {
        //_timeTillOpening = _maxTimeTillOpening;
        if (!_shopIsOpen)
        {
            if (_timeTillOpening >= 0)
            {
                _timeTillOpening -= Time.deltaTime;
            }
            if (_timeTillOpening <= 0)
            {
                _shopIsOpen = true;
                WaveController.newWave += ShopPhase;
            }
            _shopOpeningHUD.SetActive(true);
            _shopOpeningText.text = "Wave cleared. Shop opening in" + "\n" + Mathf.Round(_timeTillOpening);
        }
        else if (_shopIsOpen)
        {
            _shopOpeningHUD.SetActive(false);
        }
    }

    void ShopTurnTimer()
    {
        _timeToShop -= Time.deltaTime;  //Counts down time
        if (_timeToShop <= 0)
        {
            //If timer reaches 0 give turn to next player and reset time
            NextPlayerShopTurn();
        }
    }

    void NextPlayerShopTurn()
    {
        if (_playerToShop < PlayerParty.PlayerCharacters.Count-1)
        {
            _playerToShop++; //If the current player shopping isnt the last one in the list go to the next one
        }
        else if (_playerToShop == PlayerParty.PlayerCharacters.Count-1)
        {
            //Sets everything up for re-use after the next wave
            _playerToShop = 0;
            _shopTurns.ResetPortraitColors();
            _shopPanel.SetActive(false);
            _shopIsOpen = false;
            _waveController.IsCombatPhase = true;
        }
        FindingNemo();
        _shopTurns.SetShopInputs();
        _upgradeCosts.ShowPlayerUpgradeCosts(); //Shows the cost of all upgrades of the current player
        _timeToShop = _maxTimeToShop; //resets the shop timer
    }

    void FindingNemo()
    {
        _matchingPlayer = PlayerParty.PlayerCharacters[_playerToShop];
        _shopTurns.PlayerToShop = _matchingPlayer.PlayerID;
        if (!_waveController.IsCombatPhase)
        {
            _shopTurns.ShowPlayerToShop();
        }
    }
}
