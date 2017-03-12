using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _playerCharacter;
    public PlayerCharacter Character
    {
        get{ return _playerCharacter; }
        set{ _playerCharacter = value; }
    }

    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;
    public Image Portrait
    { 
        get {return _portrait;}
        set {_portrait = value; }
    }


    void Start()
    {
        Character.HUD = this;
    }

    void Update()
    {
        if (Character != null)
        {
            _portrait.sprite = Character.Portrait;
        }
    }
}
