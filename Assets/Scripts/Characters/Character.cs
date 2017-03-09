using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable {

    //Editor Values
    [SerializeField]protected string    _name;
    [SerializeField]protected float     _movementSpeed;
    [SerializeField]protected float     _maxHealth;
    [SerializeField]protected float     _damage;
    [SerializeField]protected float     _attackRange;
    [SerializeField]protected float     _attackSpeed;
    protected bool _isDead;

    [SerializeField]protected float _currentHealth;
    protected Animator _animator;

    //Getters & Setters
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float AttackRange
    {
        get { return _attackRange; }
        set { _attackRange = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
    }

    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    public Animator CharacterAnimator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();    //Gets the characters animator
        _currentHealth = _maxHealth;             //Sets the characters current health to its max health on spawn
    }

    public void TakeDamage(Character damageSource)
    {
        StartCoroutine(PlayAnim());
        if (_currentHealth > 0)
        {
            if(this.gameObject.tag == Tags.PLAYER & damageSource.gameObject.tag == Tags.ENEMY)
            {
                _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
            }
            if(this.gameObject.tag == Tags.ENEMY && damageSource.gameObject.tag == Tags.PLAYER)
            {
                _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
                if(_currentHealth <= 0)
                {
                    PlayerCharacter source = damageSource.GetComponent<PlayerCharacter>();
                    Enemy enemy = GetComponent<Enemy>();
                    source.Gold += enemy.GoldValue;
                }
            }
        }
    }

    IEnumerator PlayAnim()
    {
        _animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Hit", false);
    }
}
