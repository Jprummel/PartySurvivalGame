﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character, IDamageable{

    private List<GameObject> _players;
    [SerializeField]protected int _goldValue;
    private EnemySpawner _enemySpawner;
    private Image _healthBar;
    private float _healthOffset;
    [SerializeField]private Sprite[] _healthBars;

    public int GoldValue
    {
        get { return _goldValue; }
    }

    void Start()
    {
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _players = PlayerParty.Players;
        _healthBar = GetComponentInChildren<Image>();
        _healthOffset = _maxHealth;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
        }
        UpdateHealthbar();
    }

    IEnumerator DeathRoutine()
    {
        _animator.SetBool("IsDead", true);
        _isDead = true;
        _enemySpawner.spawnedEnemies.Remove(this.gameObject);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void UpdateHealthbar()
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
        ChangeHealthColor();

    }

    void ChangeHealthColor()
    {
        float percentage = _currentHealth / _maxHealth * 100;
        if(percentage > 50)
        {
            _healthBar.sprite = _healthBars[0];
        }else if(percentage >= 25 && percentage <= 50)
        {
            _healthBar.sprite = _healthBars[1];
        }else
        {
            _healthBar.sprite = _healthBars[2];
        }
    }
}
