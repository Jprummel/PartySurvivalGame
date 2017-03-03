using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopDisplay : MonoBehaviour {

    //Shop panel
    [SerializeField]private GameObject  _shopPanel;
    [SerializeField]private UpgradeDamage _damageUpgrade;
    [SerializeField]private UpgradeHealth _healthUpgrade;
    [SerializeField]private UpgradeMovementSpeed _moveSpeedUpgrade;
    
    //Shop time variables
    [SerializeField]private float       _maxTimeToShop;
                    private float       _timeToShop;
    //Inputs
    private StandaloneInputModule       _inputs;
    
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

    [SerializeField]private int     _playerToShop = 1;
    private bool    _isShopPhase;

	void Start () {
        _timeToShop = _maxTimeToShop;
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _inputs = _shopPanel.GetComponentInChildren<StandaloneInputModule>();
        FindingNemo();
        SetShopInputs();
    }

    void Update()
    {
        ShopPhase();
    }

    void ShopPhase()
    {
        if(!_waveController.IsCombatPhase){
            //shows the shop panel
            _isShopPhase = true;
            _shopPanel.SetActive(true);
            SetShopInputs();
            ShopTurnTimer(); //Runs the timer
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
        FindingNemo();
        SetShopInputs();
        ShowPlayerUpgradeCosts();
        _timeToShop = _maxTimeToShop;  

        if (_playerToShop < PlayerParty.PlayerCharacters.Count)
        {
            _playerToShop++; //If the current player shopping isnt the last one in the list go to the next one
        }
        else if (_playerToShop == PlayerParty.PlayerCharacters.Count)
        {
            //Sets everything up for re-use after the next wave
            _playerToShop = 1;
            _waveController.IsCombatPhase = true;
            _shopPanel.SetActive(false);
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

    void ShowPlayerUpgradeCosts()
    {
        _damageUpgrade.GetCurrentCost();
        _healthUpgrade.GetCurrentCost();
        _moveSpeedUpgrade.GetCurrentCost();        
    }
}
