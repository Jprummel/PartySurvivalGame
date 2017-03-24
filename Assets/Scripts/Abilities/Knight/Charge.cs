using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Ability {

    public override void UseAbility()
    {
        
    }

    public override void CancelAbility()
    {
        
    }

    IEnumerator ChargeRoutine()
    {
        _player.CharacterAnimator.SetBool("UseAbility",true);
        yield return new WaitForSeconds(1);
        _player.CharacterAnimator.SetBool("UseAbility", false);
        _player.CharacterAnimator.SetBool("EndAbility",true);
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
    }
}
