using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour {

    PlayerCharacter _playerCharacter;

    private bool _readyToAttack = true;

    void Awake()
    {  
        _playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Attack()
    {
        if (_readyToAttack)
        {
            StartCoroutine(AttackState());
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
