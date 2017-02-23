//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    EnemySpawner _enemySpawner;

    private int _enemiesToSpawn = 16;
    private int _maxEnemies = 15;
    private int _enemiesSpawned;
    private float timer;
	
    void Start()
    {
        _enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }

	void Update () {
        if (_enemiesSpawned < _enemiesToSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                NextWave();
            }
        }
        Debug.Log(_enemiesSpawned);
	}

    void NextWave()
    {
        if(_enemySpawner.spawnedEnemies.Count < _maxEnemies)
        {
            _enemySpawner.SpawnEnemy();
            _enemiesSpawned++;
        }
        timer = 0;
    }
}
