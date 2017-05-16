//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> _playerEnemies = new List<GameObject>();
    [SerializeField]private List<GameObject> _enemyTypes = new List<GameObject>();
    [SerializeField]private Transform _enemyParentObject;

    [HideInInspector]public List<GameObject> spawnedEnemies = new List<GameObject>();
    private List<Transform> _spawnpoints = new List<Transform>();

    private int _minEnemyType;
    private int _enemyTypeCount;

    void Awake()
    {
        AddEnemyTypes();
        foreach (Transform child in transform)
        {
            _spawnpoints.Add(child);
        }
    }

    public void AddEnemyTypes()
    {
        switch (GameInformation.Wave)
        {
            case 1:
                _minEnemyType = 0;
                _enemyTypeCount = 2; //2 types of peasants
                break;
            case 3:
                _enemyTypeCount = 3; //Adds last type of peasant
                break;
            case 5:
                _enemyTypeCount = 4; //Adds Militia
                break;
            case 8:
                _minEnemyType = 2; //Removes first 2 peasants
                _enemyTypeCount = 6; //Adds 2 blacksmiths
                break;
            case 10:
                _minEnemyType = 3; //Removes last peasant
                _enemyTypeCount = 7; //Adds last blacksmith
                break;
            case 15:
                _enemyTypeCount = 10; //Adds soldiers
                break;
        }
    }

    public void AddDeadPlayers()
    {
        for (int i = 0; i < _playerEnemies.Count; i++)
        {
            spawnedEnemies.Add(_playerEnemies[i]);
        }
    }

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(_minEnemyType, _enemyTypeCount);
        GameObject spawnedEnemy = Instantiate(_enemyTypes[randomEnemy]);
        spawnedEnemies.Add(spawnedEnemy);
        spawnedEnemy.transform.position = _spawnpoints[Random.Range(0, _spawnpoints.Count)].position;
        spawnedEnemy.transform.SetParent(_enemyParentObject);
    }
}
