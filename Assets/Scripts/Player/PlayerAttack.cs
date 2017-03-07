using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    PlayerCharacter _playerCharacter;
    AttackCollider _attackCollider;

    [SerializeField]private GameObject _hitbox;
    private bool _readyToAttack = true;

    void Awake()
    {  
        _playerCharacter = GetComponent<PlayerCharacter>();
        _attackCollider = _hitbox.GetComponent<AttackCollider>();
    }

    public void Attack()
    {
        if (_readyToAttack)
        {
            StartCoroutine(AttackState());
            //dealdamage(multilpier) for later on heavy and maybe combo attacks;
            _playerCharacter.DealDamage(1f, _attackCollider.Target);
            _readyToAttack = false;
            StartCoroutine(Cooldown(0.6f));
        }
    }

    IEnumerator AttackState()
    {
        _playerCharacter.CharacterAnimator.SetInteger("AttackState", 1);
        yield return new WaitForSeconds(0.01f);
        _playerCharacter.CharacterAnimator.SetInteger("AttackState", 0);
    }

    IEnumerator Cooldown(float cd)
    {       
        yield return new WaitForSeconds(cd);
        _readyToAttack = true;
    }
}
