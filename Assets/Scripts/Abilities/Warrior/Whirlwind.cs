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
            StartCoroutine(WhirlwindRoutine());
        }
    }

    IEnumerator WhirlwindRoutine()
    {
        _usingAbility = true;
        StartCoroutine(SpecialAttackDamage(0.8f,1));
        _player.CharacterAnimator.SetBool("UseAbility",true);
        _sound.PlayAbilitySound();
        yield return new WaitForSeconds(1);
        _player.CharacterAnimator.SetBool("UseAbility", false);
        _cooldown = _maxCooldown;
        _usingAbility = false;
        _abilityIsReady = false;
    }
}
