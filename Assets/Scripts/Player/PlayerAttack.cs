using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour {

    PlayerCharacter _playerCharacter;

    private bool _readyToAttack = true;
    public bool ReadyToAttack
    {
        get { return _readyToAttack; }
    }

    void Awake()
    {  
        _playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Attack()
    {
        if (_readyToAttack)
        {
            StartCoroutine(AttackState(1));
            _readyToAttack = false;
            
            StartCoroutine(Cooldown(0.6f));
        }
    }

    public void HeavyAttack()
    {
        if (_readyToAttack & !_playerCharacter.Ability.UsingAbility)
        {
            StartCoroutine(AttackState(3));
            StartCoroutine(HeavyAttackRoutine(2));
            _readyToAttack = false;
            StartCoroutine(Cooldown(1));
        }
    }

    IEnumerator AttackState(int animationAttackState)
    {
        _playerCharacter.CharacterAnimator.SetInteger("AttackState", animationAttackState);
        yield return new WaitForSeconds(0.25f);
        _playerCharacter.CharacterAnimator.SetInteger("AttackState", 0);
    }

    IEnumerator Cooldown(float cd)
    {
        yield return new WaitForSeconds(cd);
        _readyToAttack = true;
    }

    IEnumerator HeavyAttackRoutine(float modifier)
    {
        float defaultDamage = _playerCharacter.Damage;

        _playerCharacter.CanMove = false;
        _playerCharacter.Ability.CanUseAbility = false;
        _playerCharacter.Damage = _playerCharacter.Damage * modifier;
        yield return new WaitForSeconds(1);
        _playerCharacter.Damage = defaultDamage;
        _playerCharacter.Ability.CanUseAbility = true;
        _playerCharacter.CanMove = true;
    }
}
