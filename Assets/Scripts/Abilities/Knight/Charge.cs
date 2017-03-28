using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Ability {

    [SerializeField]private AnimationClip _windUp;
    [SerializeField]private AnimationClip _charge;

    private float _chargeTime;
    private float _windUpTime;

    void Start()
    {
        _chargeTime = _charge.length;
        _windUpTime = _windUp.length;
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

    public override void CancelAbility()
    {
        
    }

    IEnumerator ChargeRoutine()
    {
        Debug.Log("charge!");
        _player.CharacterAnimator.SetBool("WindUp",true);
        yield return new WaitForSeconds(_windUpTime);
        _player.CharacterAnimator.SetBool("WindUp", false);
        _player.CharacterAnimator.SetBool("Charge",true);
        yield return new WaitForSeconds(_chargeTime);
        _player.CharacterAnimator.SetBool("Charge", false);
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
    }
}
