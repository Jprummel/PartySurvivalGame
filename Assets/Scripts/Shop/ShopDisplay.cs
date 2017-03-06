﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopDisplay : MonoBehaviour {

    //Shop panel
    [SerializeField]private GameObject  _shopPanel;
    
    //Shop time variables
    [SerializeField]private float       _maxTimeToShop;
                    private float       _timeToShop;
    //
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
        FindingNemo();
        ShopPhase();
    }

    void ShopPhase()
    {
        if(!_waveController.IsCombatPhase){
            //shows the shop panel
            _shopPanel.SetActive(true);
            _shopTurns.SetShopInputs();
            ShopTurnTimer(); //Runs the timer
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
        if (_shopTurns.PlayerToShop < PlayerParty.PlayerCharacters.Count)
        {
            _shopTurns.PlayerToShop++; //If the current player shopping isnt the last one in the list go to the next one
        }
        else if (_shopTurns.PlayerToShop == PlayerParty.PlayerCharacters.Count)
        {
            //Sets everything up for re-use after the next wave
            _shopTurns.PlayerToShop = 1;
            _waveController.IsCombatPhase = true;
            _shopPanel.SetActive(false);
        }
        FindingNemo();
        _shopTurns.SetShopInputs();
        _upgradeCosts.ShowPlayerUpgradeCosts();
        _timeToShop = _maxTimeToShop;
    }

    void FindingNemo()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
            {
                if (PlayerParty.PlayerCharacters[i].PlayerID == _shopTurns.PlayerToShop)
                {
                    _matchingPlayer = PlayerParty.PlayerCharacters[i];
                }
            }
    }
}
