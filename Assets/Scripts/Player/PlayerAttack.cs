﻿using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private PlayerCharacter _player;
    private CharacterSoundFX _soundEffects;
    private int _animationAttackState;
    private float   _defaultDamage;
    private float   _modifier = 2;
    private float   _comboResetTimer;
    private float   _delayBetweenCombos;
    private bool    _readyToAttack = true;
    public bool ReadyToAttack
    {
        get { return _readyToAttack; }
    }

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
        _soundEffects = GetComponent<CharacterSoundFX>();
    }

    void Update(){
        StartComboResetTimer();
        _delayBetweenCombos -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_readyToAttack && _delayBetweenCombos <= 0)
        {
            //StartCoroutine(AttackAnimRoutine(_player.LightAttackState));
            _player.UpperBodyAnimator.SetInteger("AttackState",_player.LightAttackState);
            _soundEffects.PlayLightAttackAudio(); //Basic Attack (miss) sound
            _readyToAttack = false;
            _player.LightAttackState++;
            _comboResetTimer = 0.8f;
            if (_player.LightAttackState > _player.MaxLightAttackState)
            {
                _player.LightAttackState = 1;
                _delayBetweenCombos = 0.75f;
            }
            StartCoroutine(Cooldown(0.3f));
        }
    }

    public void HeavyAttack()
    {
        if (_readyToAttack & !_player.Ability.UsingAbility)
        {
            _player.CanMove = false;
            StartCoroutine(HeavyAttackRoutine(2));
            //StartHeavyAttack();
            _soundEffects.PlayHeavyAttackAudio(); // Heavy Attack (miss) sound
            _readyToAttack = false;
            StartCoroutine(Cooldown(1));
        }
    }

   /*IEnumerator AttackAnimRoutine(int animationAttackState)
    {
        _player.UpperBodyAnimator.SetInteger("AttackState", animationAttackState);
        yield return new WaitForSeconds(0.5f);
        _player.UpperBodyAnimator.SetInteger("AttackState", 0);
    }*/

    /*void AttackAnim(int animationAttackState)
    {

        switch (animationAttackState)
        {
            case 1:
                _player.UpperBody.AnimationState.SetAnimation(0, SpineAnimationNames.FOREHAND + _player.MoveStateName, false);
                break;
            case 2:
                _player.UpperBody.AnimationState.SetAnimation(0, SpineAnimationNames.BACKHAND + _player.MoveStateName, false);
                break;
            case 3:
                _player.UpperBody.AnimationState.SetAnimation(0, SpineAnimationNames.OVERHEAD + _player.MoveStateName, false);
                break;
        }
    }*/

    void StartComboResetTimer()
    {
        if (_comboResetTimer >= 0.0f)
        {
            _comboResetTimer -= Time.deltaTime;
        }
        if (_comboResetTimer <= 0)
        {
            _comboResetTimer = 0;
            _player.LightAttackState = 1;
        }
    }

    IEnumerator Cooldown(float cd)
    {
        yield return new WaitForSeconds(cd);
        _readyToAttack = true;
    }

    IEnumerator HeavyAttackRoutine(float modifier)
    {
        float defaultDamage = _player.Damage;
        _player.UpperBodyAnimator.SetInteger("AttackState", 3); //Test
        _player.CanMove = false;
        _player.Ability.CanUseAbility = false;
        _player.Damage = _player.Damage * modifier;
        yield return new WaitForSeconds(0.5f);
        _player.Damage = defaultDamage;
        _player.Ability.CanUseAbility = true;
        _player.CanMove = true;
        _player.UpperBodyAnimator.SetInteger("AttackState", 0); //Test
    }

    public void FinishLightAttack()
    {
        _readyToAttack = true;
    }

    public void StartHeavyAttack()
    {
        _player.UpperBodyAnimator.SetInteger("AttackState", 3);
        _player.CanMove = false;
        _player.Ability.CanUseAbility = false;
        _player.Damage = _player.Damage * _modifier;
    }

    public void FinishHeavyAttack()
    {
        Debug.Log("Sasageyo");
        _player.Damage = _player.Damage / _modifier;
        _player.Ability.CanUseAbility = true;        
        _player.CanMove = true;        
        _readyToAttack = true;
    }

    public void FinishAttackAnimation()
    {
        Debug.Log("Shinzou");
        _player.UpperBodyAnimator.SetInteger("AttackState", 0);
    }
}
