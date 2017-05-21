//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour{

    private EnemySpawner _enemySpawner;
    private EnemyPlayerScaling _playerScaling;
    public delegate void NewWaveMessage();
    public static NewWaveMessage newWave;

    ShopDisplay _shop;
    private int _enemiesToSpawn = 10;
    private int _maxEnemies = 15;
    private int _enemiesSpawned;
    private float _jeMoeder = 1.2f;//_enemyAmountModifier
    private float timer;//enemy respawn timer
    private bool _isCombatPhase = true;
    private bool _spawnedPlayers;

    public bool IsCombatPhase
    {
        get { return _isCombatPhase; }
        set { _isCombatPhase = value; }
    }

    void Start()
    {
        _playerScaling = GameObject.FindGameObjectWithTag(Tags.PLAYERPARTY).GetComponent<EnemyPlayerScaling>();
        _enemySpawner = GameObject.FindWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _shop = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
    }

    void Update()
    {
        //if there are less enemies spawned than supposed to
        if (_enemiesSpawned < _enemiesToSpawn && _isCombatPhase)
        {
            //wait 0.5s before spawning another enemy
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
        AddPlayers();
        if (_enemySpawner.spawnedEnemies.Count < _maxEnemies)
        {
            _enemySpawner.SpawnEnemy();
            _enemiesSpawned++;
        }
        timer = 0;
    }

    void AddPlayers()
    {
        if (!_spawnedPlayers)
        {
            _enemySpawner.AddDeadPlayers();
            _spawnedPlayers = true;
        }
    }

    void ResetWave()
    {
        _shop.TimeTillOpening = _shop.MaxTimeTilleOpening;
        _isCombatPhase = false;
        _enemiesSpawned = 0;
        float newEnemyAmount = _enemiesToSpawn;
        GameInformation.Wave++;
        _enemySpawner.AddEnemyTypes();
        _playerScaling.Scale();
        _spawnedPlayers = false;
        switch (GameInformation.Wave)
        {
            case 10:
                _jeMoeder = 1.10f;
                break;
            case 20:
                _jeMoeder = 1.05f;
                break;
        }
        _enemiesToSpawn = Mathf.RoundToInt(newEnemyAmount * _jeMoeder);
    }
}
