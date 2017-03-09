using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable{

    private List<GameObject> _players;
    [SerializeField]protected int _scoreValue;
    [SerializeField]protected int _goldValue;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _players = PlayerParty.Players;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
            //player.Gold += _goldValue;
            //player.Score += _scoreValue;
        }
    }

    IEnumerator DeathRoutine()
    {
        _animator.SetInteger("AnimationState", 3);
        _isDead = true;
        _enemySpawner.spawnedEnemies.Remove(this.gameObject);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
