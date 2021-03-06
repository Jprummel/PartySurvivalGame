﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Ability {

    [SerializeField]private float _maxChargeSpeed;
    [SerializeField]private float _chargeSpeed;

    [SerializeField]private AnimationClip _windUp;
    [SerializeField]private AnimationClip _charge;
    [SerializeField]private AnimationClip _intoIdle;

    private bool _charging;

    private float _chargeTime;
    private float _windUpTime;
    private float _intoIdleTime;

    protected override void Update()
    {
        base.Update();
        if (_usingAbility)
        {
            ChargePlayer();
        }
    }

    public override void UseAbility()
    {
        if(!_usingAbility && _canUseAbility && _abilityIsReady)
        {
            ChargeRoutine();
        }
    }

    void ChargePlayer()
    {
        if (_charging)
        {
            //increase charge speed overtime
            _chargeSpeed = Mathf.Lerp(_chargeSpeed, _maxChargeSpeed, Time.deltaTime);
            //float value of transform.forward
            float xDir = transform.forward.magnitude;
            if (transform.rotation.y == 1)
            {
                Debug.Log("lmaokekxd");
                //change direction if player changes direction
                xDir = -xDir;
            }

            Vector2 dir = new Vector2(xDir, 0);
            //charge player
            _player.RGB2D.MovePosition(_player.RGB2D.position + dir * _chargeSpeed * Time.deltaTime);
        }
    }

    public override void CancelAbility()
    {
        
    }

    void ChargeRoutine()
    {
        _usingAbility = true;
        _player.CanMove = false;   
        //start animation
        _sound.PlayAbilitySound();
        _player.UpperBodyAnimator.SetBool("UsingAbility", true);
        _player.LowerBodyAnimator.SetBool("UsingAbility", true);
        //start charge
        _charging = true;
        _player.Invincible = true;
        /*yield return new WaitForSeconds(_windUpTime);
        yield return new WaitForSeconds(_chargeTime);
        yield return new WaitForSeconds(_intoIdleTime);*/

        //end animation
        /*_player.UpperBodyAnimator.SetBool("UsingAbility", false);
        _player.LowerBodyAnimator.SetBool("UsingAbility", false);
        _player.Invincible = false;
        _charging = false;
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
        _player.CanMove = true;
        _chargeSpeed = 0f;
        _usingAbility = false;*/
    }

    public void FinishCharge()
    {
        Debug.Log("finito");
        _player.UpperBodyAnimator.SetBool("UsingAbility", false);
        _player.LowerBodyAnimator.SetBool("UsingAbility", false);
        _player.Invincible = false;
        _charging = false;
        _cooldown = _maxCooldown;
        _abilityIsReady = false;  
        _player.CanMove = true;
        _chargeSpeed = 0f;
        _usingAbility = false;
        _player.RGB2D.velocity = Vector2.zero;
    }
}
