using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    [SerializeField]protected string _abilityName;
    [SerializeField]protected float _maxCooldown;
    [SerializeField]protected Image _abilityImage;
    protected PlayerCharacter _player;
    protected bool _abilityIsReady;    
    protected float _cooldown;
    protected float _damageModifier;
    protected bool _usingAbility;

    public bool UsingAbility
    {
        get { return _usingAbility; }
    }

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
    }

    public bool AbilityIsReady
    {
        get { return _abilityIsReady; }
    }

    protected virtual void Update()
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

    public virtual void CancelAbility()
    {

    }

    protected IEnumerator SpecialAttackDamage(float modifier, float time)
    {
        float defaultDamage = _player.Damage;

        _player.Damage = _player.Damage * modifier;
        yield return new WaitForSeconds(time);
        _player.Damage = defaultDamage;
    }
}
