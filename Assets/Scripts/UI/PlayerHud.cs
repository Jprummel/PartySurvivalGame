using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHud : MonoBehaviour {

    private PlayerCharacter _player;
    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _abilityImage;
    [SerializeField]private Image _abilityCooldownIndicator;
    [SerializeField]private Image _enemyPlayerHealthBar;

    void Start()
    {
        _player = GetComponentInParent<PlayerCharacter>();
        _player.HUD = this;
        _abilityImage.sprite = _player.Ability.AbilityImage;
    }

	void Update () {
        SetHealthBar();
        ShowAbilityCooldown();
	}

    void SetHealthBar()
    {
        _healthBar.DOFillAmount(_player.CurrentHealth / _player.MaxHealth, 1);
    }

    void ShowAbilityCooldown()
    {
        float cooldown = _player.Ability.Cooldown;
        float maxCooldown = _player.Ability.MaxCooldown;

        if (!_player.Ability.AbilityIsReady)
        {
            _abilityCooldownIndicator.DOFillAmount(cooldown / maxCooldown, 0.1f).ChangeStartValue(1);
        }
    }

    public void SetNewHealthBar()
    {
        if (!_player.IsAlly)
        {
            _healthBar.sprite = _enemyPlayerHealthBar.sprite;
        }
    }
}