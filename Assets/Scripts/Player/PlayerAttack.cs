using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    PlayerCharacter _playerCharacter;
    SlashCollider _slashCollider;

    [SerializeField]private GameObject _hitbox;
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerCharacter = GetComponent<PlayerCharacter>();
        _slashCollider = _hitbox.GetComponent<SlashCollider>();
    }

    public void Attack()
    {
        StartCoroutine(AttackState());
        //dealdamage(multilpier) for later on heavy and maybe combo attacks;
        _playerCharacter.DealDamage(1f, _slashCollider.Target);
    }

    IEnumerator AttackState()
    {
        _anim.SetInteger("AttackState", 1);
        yield return new WaitForSeconds(0.01f);
        _anim.SetInteger("AttackState", 0);
    }
}
