using System.Collections;
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

    void Start()
    {
        _chargeTime = _charge.length;
        _windUpTime = _windUp.length;
        _intoIdleTime = _intoIdle.length / 1.5f;
    }

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
            StartCoroutine(ChargeRoutine());
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

    IEnumerator ChargeRoutine()
    {
        _usingAbility = true;
        _player.CanMove = false;   
        //start animation spaghettios
        _sound.PlayAbilitySound();
        _player.CharacterAnimator.SetBool("WindUp",true);
        //start charge
        _charging = true;
        _player.Invincible = true;
        yield return new WaitForSeconds(_windUpTime);
        _player.CharacterAnimator.SetBool("WindUp", false);

        _player.CharacterAnimator.SetBool("Charge",true);
        yield return new WaitForSeconds(_chargeTime);
        _charging = false;
        _player.Invincible = false;
        //end charge
        _player.CharacterAnimator.SetBool("Charge", false);

        _player.CharacterAnimator.SetBool("IntoIdle", true);
        yield return new WaitForSeconds(_intoIdleTime);
        _player.CharacterAnimator.SetBool("IntoIdle", false);
        //end animation spaghettios
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
        _player.CanMove = true;
        _chargeSpeed = 0f;
        _usingAbility = false;
    }
}
