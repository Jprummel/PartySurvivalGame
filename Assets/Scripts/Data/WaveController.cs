//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    EnemySpawner _enemySpawner;

    private int _enemiesToSpawn = 10;
    private int _maxEnemies = 15;
    private int _enemiesSpawned;
    private float _jeMoeder = 1.2f;//_enemyAmountModifier
    private float timer;//enemy respawn timer
    private bool _isCombatPhase = true;

    public bool IsCombatPhase
    {
        get { return _isCombatPhase; }
        set { _isCombatPhase = value; }
    }

    void Start()
    {
        _enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        Debug.Log(_isCombatPhase);
    }

    void Update()
    {//if there are less enemies spawned than supposed to
        if (_enemiesSpawned < _enemiesToSpawn && _isCombatPhase)
        {//wait 0.5s before spawning another enemy
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                SpawnEnemy();
            }
        }//if the right amount of enemies are spawned, the list is empty and the players arent shopping.
        if (_enemiesSpawned == _enemiesToSpawn && _enemySpawner.spawnedEnemies.Count == 0 && _isCombatPhase)
        {
            //reset wave values
            ResetWave();
        }

    }

    void SpawnEnemy()
    {
        if (_enemySpawner.spawnedEnemies.Count < _maxEnemies)
        {
            _enemySpawner.SpawnEnemy();
            _enemiesSpawned++;
        }
        timer = 0;
    }

    void ResetWave()
    {
        _isCombatPhase = false;
        _enemiesSpawned = 0;
        float newEnemyAmount = _enemiesToSpawn;
        GameInformation.Wave++;
        WaveDisplay.updateWave += ResetWave;
        switch (GameInformation.Wave)
        {
            case 10:
                Debug.Log("wave 10");
                _jeMoeder = 1.10f;
                break;
            case 20:
                Debug.Log("wave 20");
                _jeMoeder = 1.05f;
                break;
        }
        _enemiesToSpawn = Mathf.RoundToInt(newEnemyAmount * _jeMoeder);
    }
}
