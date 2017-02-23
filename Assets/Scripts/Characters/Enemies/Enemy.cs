using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable  {

    [SerializeField]protected int _scoreValue;
    [SerializeField]protected int _goldValue;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        //StartCoroutine(DeathRoutine());
    }

    /*public void TakeDamage(PlayerCharacter player)
    {
        _currentHealth -= player.Damage;
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
            player.Gold += _goldValue;
            player.Score += _scoreValue;
        }
    }*/

    public void TakeDamage(float damage)
    {
        Debug.Log("take damage");
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
            //add gold?
            //add score?
        }
    }

    IEnumerator DeathRoutine()
    {
        //_animator.SetBool("isDead", true);
        //_enemySpawner.spawnedEnemies.Remove(this.gameObject);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
