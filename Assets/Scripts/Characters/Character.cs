using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    //Editor Values
    [SerializeField]protected string    _name;
    [SerializeField]protected float     _movementSpeed;
    [SerializeField]protected float     _maxHealth;
    [SerializeField]protected float     _damage;
    [SerializeField]protected float     _attackSpeed;

    protected float _currentHealth;
    protected Character _damageSource;
    
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

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    protected Animator _animator;

    public Character DamageSource
    {
        get { return _damageSource; }
        set { _damageSource = value; }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();   //Gets the characters animator
        _currentHealth = _maxHealth;            //Sets the characters current health to its max health on spawn
    }
}
