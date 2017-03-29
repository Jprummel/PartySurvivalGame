using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Ability {

    [SerializeField]private AnimationClip _windUp;
    [SerializeField]private AnimationClip _charge;
    [SerializeField]private AnimationClip _intoIdle;

    private float _chargeTime;
    private float _windUpTime;
    private float _intoIdleTime;

    void Start()
    {
        _chargeTime = _charge.length;
        _windUpTime = _windUp.length;
        _intoIdleTime = _intoIdle.length;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void UseAbility()
    {
        Debug.Log("charge");
        if(!_usingAbility && _abilityIsReady)
        {
            StartCoroutine(ChargeRoutine());
        }
    }

    void ChargePlayer()
    {
        Vector2 dir = new Vector2(/*looking direction*/, 0);
        _player.RGB2D.MovePosition(_player.RGB2D.position + dir * Time.deltaTime);
    }

    public override void CancelAbility()
    {
        
    }

    IEnumerator ChargeRoutine()
    {
        _usingAbility = true;
        _player.CanMove = false;   
        //start animation spaghettios
        _player.CharacterAnimator.SetBool("WindUp",true);
        yield return new WaitForSeconds(_windUpTime);
        _player.CharacterAnimator.SetBool("WindUp", false);
        _player.CharacterAnimator.SetBool("Charge",true);
        yield return new WaitForSeconds(_chargeTime);
        _player.CharacterAnimator.SetBool("Charge", false);
        _player.CharacterAnimator.SetBool("IntoIdle", true);
        yield return new WaitForSeconds(_intoIdleTime);
        _player.CharacterAnimator.SetBool("IntoIdle", false);
        //end animation spaghettios
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
        _player.CanMove = true;
        _usingAbility = false;
    }
}
