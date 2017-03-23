using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : Ability {

	// Use this for initialization
	void Start () {
        _abilityIsReady = true;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        
	}

    public override void UseAbility()
    {
        StartCoroutine(WhirlwindRoutine());
    }

    IEnumerator WhirlwindRoutine()
    {
        _usingAbility = true;
        _player.CharacterAnimator.SetBool("UseAbility",true);
        yield return new WaitForSeconds(1);
        _player.CharacterAnimator.SetBool("UseAbility", false);
        _cooldown = _maxCooldown;
    }


}
