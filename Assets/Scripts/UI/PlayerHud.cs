using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _player;
    private int _hudID;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;
    [SerializeField]private Image _healthBar;

    public int HUDId
    {
        get { return _hudID; }
        set { _hudID = value; }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void DisplayGold()
    {
        _gold.text = _player.Gold.ToString();
    }

    void DisplayHealthBar()
    {
        _healthBar.fillAmount = _player.CurrentHealth / _player.MaxHealth;
    }
}
