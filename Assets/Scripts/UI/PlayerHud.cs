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

    [SerializeField]private Image _enemyHealthBar;
    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _portrait;
    [SerializeField]private Text _gold;
    [SerializeField]private Text _rankText;
    [SerializeField]private Image _abilityImage;
    [SerializeField]private Text _abilityCooldownText;
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
    private Color _inactiveColor = new Color();

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
        _inactiveColor = new Color(0.20f, 0.20f, 0.20f, 1);
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
        _healthBar.fillAmount = Character.CurrentHealth / Character.MaxHealth;
    }

    void ShowAbilityCooldown()
    {
        if (_playerCharacter.Ability.Cooldown > 0)
        {
            _abilityCooldownText.text = _playerCharacter.Ability.Cooldown.ToString("N0"); //Shows player abilities cooldown (without decimals)
        }
        else if (_playerCharacter.Ability.Cooldown <= 0)
        {
            _abilityCooldownText.text = ""; //If ability is not on cooldown dont show text
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
