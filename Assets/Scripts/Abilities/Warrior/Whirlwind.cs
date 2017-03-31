﻿using System.Collections;
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
        if (_abilityIsReady)
        {
            StartCoroutine(WhirlwindRoutine());
        }
    }

    IEnumerator WhirlwindRoutine()
    {
        _usingAbility = true;
        StartCoroutine(SpecialAttackDamage(0.75f,1));
        _player.CharacterAnimator.SetBool("UseAbility",true);
        _sound.PlayAbilitySound();
        yield return new WaitForSeconds(1);
        _player.CharacterAnimator.SetBool("UseAbility", false);
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
    }
}
