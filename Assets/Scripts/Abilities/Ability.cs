using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    protected CharacterSoundFX _sound;
    [SerializeField]protected string _abilityName;
    [SerializeField]protected float _maxCooldown;
    [SerializeField]protected Sprite _abilityImage;
    protected PlayerCharacter _player;
    protected bool _abilityIsReady;
    protected bool _canUseAbility;
    protected float _cooldown;
    protected float _damageModifier;
    protected bool _usingAbility;

    public bool UsingAbility
    {
        get { return _usingAbility; }
    }

    public Sprite AbilityImage
    {
        get { return _abilityImage; }
    }

    public float Cooldown
    {
        get { return _cooldown; }
    }

    public float MaxCooldown
    {
        get { return _maxCooldown; }
    }

    void Awake()
    {
        _sound = GetComponent<CharacterSoundFX>();
        _player = GetComponent<PlayerCharacter>();
        _abilityIsReady = true;
        _canUseAbility = true;
    }

    public bool AbilityIsReady
    {
        get { return _abilityIsReady; }
    }

    public bool CanUseAbility
    {
        get { return _canUseAbility; }
        set { _canUseAbility = value; }
    }

    protected virtual void Update()
    {
        if (!_abilityIsReady)
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0)
            {
                _abilityIsReady = true;
                _canUseAbility = true;
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
