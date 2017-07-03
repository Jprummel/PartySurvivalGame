using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : Ability {

	void Start () {
        _abilityIsReady = true;
	}
	
	protected override void Update () {
        base.Update();
	}

    public override void UseAbility()
    {
        if (_abilityIsReady && _canUseAbility && !_usingAbility)
        {
            WhirlwindStart();
        }
    }

    void WhirlwindStart()
    {
        _player.DefaultDamage = _player.Damage;
        _usingAbility = true;
        _player.UpperBodyAnimator.SetBool("UsingAbility", true);
        _player.LowerBodyAnimator.SetBool("UsingAbility", true);
        StartCoroutine(SpecialAttackDamage(0.8f, 1));
        _sound.PlayAbilitySound();
    }

    IEnumerator WhirlwindRoutine()
    {
        _player.DefaultDamage = _player.Damage;
        _usingAbility = true;
        _player.UpperBodyAnimator.SetBool("UsingAbility", true);
        _player.LowerBodyAnimator.SetBool("UsingAbility", true);
        StartCoroutine(SpecialAttackDamage(0.8f, 1));
        _sound.PlayAbilitySound();
        yield return new WaitForSeconds(0.9f);
    }

    public void FinishWhirlwind()
    {
        _player.Damage = _player.DefaultDamage;
        Debug.Log(_player.Damage + "DMG " + _player.DefaultDamage);
        _player.UpperBodyAnimator.SetBool("UsingAbility", false);
        _player.LowerBodyAnimator.SetBool("UsingAbility", false);
        _cooldown = _maxCooldown;
        _usingAbility = false;
        _abilityIsReady = false;
    }
}
