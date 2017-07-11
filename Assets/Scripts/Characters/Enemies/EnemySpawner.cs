using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

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
                _enemyTypeCount = 0; //Peasants
                break;
            case 5:
                _enemyTypeCount = 1; //Adds Militia
                break;

            case 15:
                _enemyTypeCount = 2; //Adds soldiers
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
