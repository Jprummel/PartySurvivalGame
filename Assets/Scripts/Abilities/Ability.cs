using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    protected string _abilityName;
    protected Image _abilityImage;
    protected bool _abilityIsReady;
    protected float _maxCooldown;
    protected float _cooldown;
    protected float _damageModifier;

    public bool AbilityIsReady
    {
        get { return _abilityIsReady; }
    }

    void Update()
    {
        if (!_abilityIsReady)
        {
            Debug.Log("Not ready");
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0)
            {
                _abilityIsReady = true;
            }
        }
    }

    public virtual void UseAbility()
    {

    }
}
