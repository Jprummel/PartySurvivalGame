using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

    private PlayerCharacter _player;

    private void Awake()
    {
        _player.GetComponentInParent<PlayerCharacter>();
    }

    void CompleteAttack()
    {
        _player.UpperBodyAnimator.SetInteger("AttackState", 0);
    }

    void CompleteHeavyAttack()
    {
        _player.CanMove = true;
        _player.Ability.CanUseAbility = true;
        _player.UpperBodyAnimator.SetInteger("AttackState", 0);
    }

    void CompleteAbility()
    {
        _player.Ability.UsingAbility = false;
        _player.Ability.Cooldown = _player.Ability.MaxCooldown;
    }
}
