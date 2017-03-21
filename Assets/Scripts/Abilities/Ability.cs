using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    [SerializeField]protected string _abilityName;
    [SerializeField]protected float _maxCooldown;
    [SerializeField]protected Image _abilityImage;
    protected bool _abilityIsReady;    
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
                Debug.Log("Ready");
                _abilityIsReady = true;
            }
        }
    }

    public virtual void UseAbility()
    {

    }
}
