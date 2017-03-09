﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    [SerializeField]protected int _playerID;

    private GameObject  _hitBox;
    private string      _color;
    protected float     _gold;
    protected int       _score;

    private float _currrentDamageCost = 500;
    private float _currentHealthCost = 500;
    private float _currentMoveSpeedCost = 500;

    public float CurrentDamageCost 
    {
        get { return _currrentDamageCost; }
        set { _currrentDamageCost = value; }
    }
    public float CurrentHealthCost 
    {
        get { return _currentHealthCost; }
        set { _currentHealthCost = value; }
    }
    public float CurrentMoveSpeedCost
    {
        get { return _currentMoveSpeedCost; }
        set { _currentMoveSpeedCost = value; }
    }

    protected enum PlayerState
    {
        ALIVE,
        DEAD,
        ENEMY
    }

    protected PlayerState _currentState;

    public int PlayerID
    {
        get { return _playerID; }
        set { _playerID = value; }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public float Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    protected override void Awake()
    {
        _hitBox = transform.GetChild(0).gameObject;
        base.Awake();
    }

    void Update()
    {
        if(CurrentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine()
    {
        _animator.SetBool("IsDead", true);
        _currentState = PlayerState.DEAD;
        yield return new WaitForSeconds(1);
        PlayerParty.Players.Remove(this.gameObject);
        PlayerParty.PlayerCharacters.Remove(this);
        gameObject.SetActive(false);
    }

    void BecomeEnemy()
    {
        _currentState = PlayerState.ENEMY;
        this.tag = Tags.ENEMY;
    }

    public void DealDamage(float multiplier, List<GameObject> target)
    {
        StartCoroutine(EnableHitbox(0.2f));
        StartCoroutine(AttackTargets(target));
    }

    IEnumerator EnableHitbox(float duration)
    {
        if (!_hitBox.active)
        {
            yield return new WaitForSeconds(0.1f);
            _hitBox.SetActive(true);
            yield return new WaitForSeconds(duration);
            _hitBox.SetActive(false);
        }
    }

    IEnumerator AttackTargets(List<GameObject> target)
    {
        //float damage = Damage * multiplier;
        //hitbox duration
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < target.Count; i++)
        {
            ExecuteEvents.Execute<IDamageable>(target[i], null, (x, y) => x.TakeDamage(Damage));
        }
    }
}