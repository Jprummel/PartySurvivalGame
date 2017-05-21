using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewPlayerHud : MonoBehaviour {

    [SerializeField]private PlayerCharacter _player;
    [SerializeField]private Image _healthBar;
    [SerializeField]private Image _abilityImage;
    [SerializeField]private Image _abilityCooldownIndicator;

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
            //_abilityCooldownSlider.fillAmount = 1;
            _abilityCooldownIndicator.DOFillAmount(cooldown / maxCooldown, 0.1f).ChangeStartValue(1);
        }
    }
}