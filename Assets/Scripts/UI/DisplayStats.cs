using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayStats : MonoBehaviour {

    [SerializeField]private Image _portrait;
    [SerializeField]private Text _playerNumberText;
    [SerializeField]private Text _statDisplayText;
    [SerializeField]private Text _statValuesText;
    [SerializeField]private Text _availableGold;
    [SerializeField]private Text _totalEarnedGold;
    [SerializeField]private PlayerCharacter _player;
    private ShopDisplay _display;


    void Start () {
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        
	}
	
	void Update () {
        if(_display.MatchingPlayer != null){
            DisplayPortrait();
            DisplayStatValues();
            DisplayAvailableGold();
            DisplayTotalEarnedGold();
            DisplayStatNames();
        }
    }

    void DisplayPortrait()
    {
        _portrait.sprite = _display.MatchingPlayer.Portrait;
    }

    void DisplayPlayerNumber()
    {
        _playerNumberText.text = "Player " + _display.MatchingPlayer.PlayerID;
    }

    void DisplayStatNames()
    {
        _statDisplayText.text = "Class" + "\n" +
                                "Damage" + "\n" +
                                "Health" + "\n" +
                                "Move Speed";   
    }

    void DisplayStatValues()
    {
        _statValuesText.text =  _display.MatchingPlayer.Name + "\n" +
                                _display.MatchingPlayer.Damage + "\n" +
                                _display.MatchingPlayer.MaxHealth + "\n" +
                                _display.MatchingPlayer.MovementSpeed;
    }

    void DisplayAvailableGold()
    {
        _availableGold.text = "Gold : " + _display.MatchingPlayer.Gold;
    }

    void DisplayTotalEarnedGold()
    {
        _totalEarnedGold.text = "Total Earned : " + _display.MatchingPlayer.TotalGoldEarned;
    }
}
