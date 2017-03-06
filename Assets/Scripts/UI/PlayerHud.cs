using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _player;
    private int _hudID;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;
    [SerializeField]private Text _score;
    [SerializeField]private Image _healthBar;

    public int HUDId
    {
        get { return _hudID; }
        set { _hudID = value; }
    }

    public PlayerCharacter Player
    {
        get { return _player; }
        set { _player = value; }
    }

	void Start () {
		_portrait = Resources.Load("Art/Sprites/UI/Portraits/" + _player.Name + "_" + _player.Color) as Image;
	}
	
	void Update () {
        DisplayGold();
        DisplayHealthBar();
        DisplayScore();
	}

    void DisplayGold()
    {
        _gold.text = _player.Gold.ToString();
    }

    void DisplayHealthBar()
    {
        _healthBar.fillAmount = _player.CurrentHealth / _player.MaxHealth;
    }

    void DisplayScore()
    {
        _score.text = _player.Score.ToString();
    }
}
