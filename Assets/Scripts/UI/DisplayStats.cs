using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayStats : MonoBehaviour {

    [SerializeField]private Text _playerName;
    [SerializeField]private Text _statDisplayText;
    [SerializeField]private Text _statValuesText;
    [SerializeField]private PlayerCharacter _player;

	void Start () {
        DisplayStatNames();
	}
	
	void Update () {
        DisplayStatValues();
	}

    void DisplayStatNames()
    {
        _playerName.text = _player.Name;
        _statDisplayText.text = "Damage" + "\n" +
                                "Health" + "\n" +
                                "Move Speed";
    }

    void DisplayStatValues()
    {
        _statValuesText.text =  _player.Damage + "\n" +
                                _player.MaxHealth + "\n" +
                                _player.MovementSpeed;
    }

}
