using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable{

    private List<GameObject> _players;
    [HideInInspector]public Vector2 closestTarget;
    private float _distToPlayer;
    public float DistToPlayer
    {
        get { return _distToPlayer; }
    }
    private GameObject _target;
    public GameObject Target
    {
        get { return _target; }
    }

    [SerializeField]protected int _scoreValue;
    [SerializeField]protected int _goldValue;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _players = PlayerParty.Players;
        //StartCoroutine(DeathRoutine());
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
            //player.Gold += _goldValue;
            //player.Score += _scoreValue;
        }
        CalculateDist();
    }

    /*public void TakeDamage(float damage)
    {
        Debug.Log("take damage");
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
            //player.Gold += _goldValue;
            //player.Score += _scoreValue;
        }
    }*/

    IEnumerator DeathRoutine()
    {
        //_animator.SetBool("isDead", true);
        _animator.SetInteger("AnimationState", 3);
        _enemySpawner.spawnedEnemies.Remove(this.gameObject);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    void CalculateDist()
    {
        float ClosestDistance = 420;

        for (int i = 0; i < _players.Count; i++)
        {
            _distToPlayer = Vector2.Distance(transform.position, _players[i].transform.position);
            //Debug.Log(_distToPlayer);

            if (_distToPlayer < ClosestDistance)
            {
                ClosestDistance = _distToPlayer;
                closestTarget = _players[i].transform.position;
                _target = _players[i].gameObject;
            }
        }
    }
}
