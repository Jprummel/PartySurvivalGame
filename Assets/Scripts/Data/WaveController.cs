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
    private float timer;
    [SerializeField]
    private int _timeBetweenWaves;
    private bool _waiting;
    private bool _isCombatPhase = true;

    public bool IsCombatPhase
    {
        get { return _isCombatPhase; }
        set { _isCombatPhase = value; }
    }

    void Start()
    {
        _isCombatPhase = false;
        _enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        if (_enemiesSpawned < _enemiesToSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                SpawnEnemy();
            }
        }
        if (_enemiesSpawned == _enemiesToSpawn && _enemySpawner.spawnedEnemies.Count == 0 && !_waiting)
        {
            _isCombatPhase = false;
            //StartCoroutine(NextWave());
        }
        if (_enemiesSpawned == _enemiesToSpawn && _enemySpawner.spawnedEnemies.Count == 0 && !_waiting)
        {
            StartCoroutine(NextWave());
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

    IEnumerator NextWave()
    {
        _waiting = true;
        yield return new WaitForSeconds(_timeBetweenWaves);
        _enemiesSpawned = 0;
        float newEnemyAmount = _enemiesToSpawn;
        GameInformation.Wave++;

        switch (GameInformation.Wave)
        {
            case 10:
                Debug.Log("wave 15");
                _jeMoeder = 1.10f;
                break;
            case 20:
                Debug.Log("wave 20");
                _jeMoeder = 1.05f;
                break;
        }

        _enemiesToSpawn = Mathf.RoundToInt(newEnemyAmount * _jeMoeder);
        _waiting = false;
    }
}
