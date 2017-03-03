using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayStats : MonoBehaviour {

    [SerializeField]private Text _playerName;
    [SerializeField]private Text _statDisplayText;
    [SerializeField]private Text _statValuesText;
    [SerializeField]private Text _availableGold;
    [SerializeField]private PlayerCharacter _player;
    private ShopDisplay _display;


    void Start () {
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        
	}
	
	void Update () {
        if(_display.MatchingPlayer != null){
            DisplayStatValues();
            DisplayAvailableGold();
            DisplayStatNames();
        }
    }

    void DisplayStatNames()
    {
            _playerName.text = _display.MatchingPlayer.Name;
            _statDisplayText.text = "Damage" + "\n" +
                                    "Health" + "\n" +
                                    "Move Speed";   
    }

    void DisplayStatValues()
    {
        _statValuesText.text =  _display.MatchingPlayer.Damage + "\n" +
                                _display.MatchingPlayer.MaxHealth + "\n" +
                                _display.MatchingPlayer.MovementSpeed;
    }

    void DisplayAvailableGold()
    {
        _availableGold.text = "Gold : " + _display.MatchingPlayer.Gold;
    }
}
