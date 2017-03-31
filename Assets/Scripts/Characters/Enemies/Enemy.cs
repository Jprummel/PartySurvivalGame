using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character, IDamageable{

    [SerializeField]protected float _damageGrowFactor;
    [SerializeField]protected float _healthGrowFactor;
    [SerializeField]protected float _goldValueGrowFactor;
    private List<GameObject> _players;
    private EnemySpawner _enemySpawner;
    private Image _healthBar;
    private float _healthOffset;
    [SerializeField]private Sprite[] _healthBars;

    protected override void Awake()
    {
        _maxHealth = Mathf.RoundToInt(_maxHealth + Mathf.Pow(GameInformation.Wave, _healthGrowFactor)); //Scales max health with wave and growth factor
        _damage = _damage + Mathf.Pow(GameInformation.Wave, _damageGrowFactor); //Scales damage with wave and growth factor
        _goldValue = Mathf.RoundToInt(_goldValue + Mathf.Pow(GameInformation.Wave, _goldValueGrowFactor)); //Scales gold value with wave and growth factor

        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _players = PlayerParty.Players;
        _healthBar = GetComponentInChildren<Image>();
        _healthOffset = _maxHealth;
        base.Awake();
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
        _isDead = true;
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        _animator.SetBool("IsDead", true);
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
