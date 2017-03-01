using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopDisplay : MonoBehaviour {

    [SerializeField]private GameObject  _shopPanel;
    [SerializeField]private float       _maxTimeToShop;
                    private float       _timeToShop;
    private StandaloneInputModule       _inputs;
    
    private WaveController  _waveController;
    private PlayerCharacter _matchingPlayer;
    public  PlayerCharacter MatchingPlayer
    {
        get { return _matchingPlayer; }
        set { _matchingPlayer = value; }
    }

    private int     _playerToShop = 1;
    private bool    _isShopPhase;

	void Start () {
        _timeToShop = _maxTimeToShop;
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _inputs = _shopPanel.GetComponentInChildren<StandaloneInputModule>();
        SetShopInputs();
    }

    void Update()
    {
        FindingNemo();
        ShopPhase();
    }

    void ShopPhase()
    {
        if(!_waveController.IsCombatPhase){
            //shows the shop panel
            _isShopPhase = true;
            _shopPanel.SetActive(true);
            ShopTurnTimer(); //Runs the timer
        }
        if (!_isShopPhase)
        {
            //Goes back to combat phase and closes the shop
            //Also resets the timer and player to shop for the next wave
            _waveController.IsCombatPhase = true;
            _shopPanel.SetActive(false);
            _playerToShop = 1;
            _timeToShop = _maxTimeToShop;
        }
    }

    void SetShopInputs()
    {
        //Sets input to every individual player during his turn
        _inputs.horizontalAxis = InputAxes.LEFT_JOYSTICK_X + _playerToShop;
        _inputs.verticalAxis = InputAxes.LEFT_JOYSTICK_Y + _playerToShop;
        _inputs.submitButton = InputAxes.XBOX_A + _playerToShop;
        _inputs.cancelButton = InputAxes.XBOX_B + _playerToShop;
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
        if (_playerToShop < PlayerParty.PlayerCharacters.Count)
        {
            _playerToShop++;
            _timeToShop = _maxTimeToShop;
            SetShopInputs();
        }
        else if (_playerToShop == PlayerParty.PlayerCharacters.Count)
        {
            _isShopPhase = false;
            _timeToShop = _maxTimeToShop;
        }
    }

    void FindingNemo()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            if (PlayerParty.PlayerCharacters[i].PlayerID == _playerToShop)
            {
                _matchingPlayer = PlayerParty.PlayerCharacters[i];
            }
        }
    }
}
