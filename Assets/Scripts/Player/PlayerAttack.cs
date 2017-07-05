using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private PlayerCharacter _player;
    private CharacterSoundFX _soundEffects;
    private int _animationAttackState;
    private float   _modifier = 2;
    private float   _comboResetTimer;
    private float   _delayBetweenCombos;
    private bool _isAttacking;
    private bool    _readyToAttack = true;
    public bool ReadyToAttack
    {
        get { return _readyToAttack; }
    }

    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
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
            _player.UpperBodyAnimator.SetInteger("AttackState",_player.LightAttackState);
            _soundEffects.PlayLightAttackAudio(); //Basic Attack (miss) sound
            _readyToAttack = false;
            _isAttacking = true;
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
            _readyToAttack = false;
            _isAttacking = true;
            StartHeavyAttack();
            _soundEffects.PlayHeavyAttackAudio(); // Heavy Attack (miss) sound    
            StartCoroutine(Cooldown(1));
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

    public void FinishLightAttack()
    {
        _readyToAttack = true;
    }

    public void StartHeavyAttack()
    {
        
        _player.UpperBodyAnimator.SetInteger("AttackState", 3);
        _player.CanMove = false;
        _player.Ability.CanUseAbility = false;
        if (_player.Damage != _player.DefaultDamage * _modifier)
        {
            _player.Damage *= _modifier;
        }
    }

    public void FinishHeavyAttack()
    {
        _player.Damage = _player.DefaultDamage;
    }

    public void FinishAttackAnimation()
    {
        _isAttacking = false;
        _player.UpperBodyAnimator.SetInteger("AttackState", 0);
        _player.Ability.CanUseAbility = true;
        _player.CanMove = true;
        _readyToAttack = true;
    }
}
