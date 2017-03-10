using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _playerCharacter;
    public PlayerCharacter PlayerCharacter
    {
        get{ return _playerCharacter; }
        set{ _playerCharacter = value; }
    }

    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;


    void Awake()
    {
        //_portrait.sprite = PlayerCharacter.Portrait;
    }

    void Update()
    {
        _portrait.sprite = PlayerCharacter.Portrait;
    }
}
