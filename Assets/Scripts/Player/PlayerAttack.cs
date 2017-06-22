using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    PlayerCharacter _player;
    private float   _defaultDamage;
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
    }

    void Update(){
        StartComboResetTimer();
        _delayBetweenCombos -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_readyToAttack && _delayBetweenCombos <= 0)
        {
            _player.Animations.PlayerAttackAnimation(_player.LightAttackState);
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
            //_player.Animations.PlayerAttackAnimation(3);
            StartCoroutine(HeavyAttackRoutine(2));
            _readyToAttack = false;
            StartCoroutine(Cooldown(1));
        }
    }

   

    void AttackAnim(int animationAttackState)
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
    }

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
}
