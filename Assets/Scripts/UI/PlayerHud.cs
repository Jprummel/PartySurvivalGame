﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _playerCharacter;
    public PlayerCharacter Character
    {
        get{ return _playerCharacter; }
        set{ _playerCharacter = value; }
    }

    [SerializeField]private Image _enemyHealthBar;
    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;
    [SerializeField]private Text _rankText;
    [SerializeField]private Image _abilityImage;
    [SerializeField]private Image _abilityCooldownSlider;

    public Image Portrait
    { 
        get {return _portrait;}
        set {_portrait = value; }
    }

    public Image HealthBar
    {
        get { return _healthBar; }
        set { _healthBar = value; }
    }

    public Text RankText
    {
        get { return _rankText; }
        set { _rankText = value; }
    }

    public Image AbilityImage
    {
        get { return _abilityImage; }
        set { _abilityImage = value; }
    }

    private Color _defaultColor = new Color();

    public Color DefaultColor
    {
        get { return _defaultColor; }
    }

    public Color InactiveColor
    {
        get { return _defaultColor; }
    }

    void Start()
    {
        Character.HUD = this;
        _defaultColor = new Color(255, 255, 255, 1);
    }

    void Update()
    {
        SetPortrait();
        SetHealthBar();
        SetGold();
        SetAbilityImage();
        ShowAbilityCooldown();
    }

    void SetPortrait()
    {
        if (Character != null)
        {
            _portrait.sprite = Character.Portrait;
        }
    }

    void SetAbilityImage()
    {
        _abilityImage.sprite = _playerCharacter.Ability.AbilityImage; //Sets ability image in HUD to fit the one passed into the ability script
    }

    void SetHealthBar()
    {
        _healthBar.DOFillAmount(Character.CurrentHealth / Character.MaxHealth, 1);
        //_healthBar.fillAmount = Character.CurrentHealth / Character.MaxHealth;
    }

    void ShowAbilityCooldown()
    {
        float cooldown = _playerCharacter.Ability.Cooldown;
        float maxCooldown = _playerCharacter.Ability.MaxCooldown;

        if(!_playerCharacter.Ability.AbilityIsReady)
        {
            _abilityCooldownSlider.DOFillAmount(cooldown / maxCooldown,1);
            //_abilityCooldownSlider.fillAmount = cooldown / maxCooldown; 
        }
    }

    void SetGold()
    {
        _gold.text = Character.Gold.ToString("N0");
    }

    public void SetNewHealthBar()
    {
        _healthBar.sprite = _enemyHealthBar.sprite;
    }
}
