//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]private List<GameObject> _enemyTypes = new List<GameObject>();
    [SerializeField]private Transform _enemyParentObject;

    [HideInInspector]public List<GameObject> spawnedEnemies = new List<GameObject>();
    private List<Transform> _spawnpoints = new List<Transform>();

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
                _enemyTypeCount = 2; //2 types of peasants
                break;
            case 3:
                _enemyTypeCount = 3; //Adds last type of peasant
                break;
            case 5:
                _enemyTypeCount = 4; //Adds Militia
                break;
        }
    }

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, _enemyTypeCount);
        GameObject spawnedEnemy = Instantiate(_enemyTypes[randomEnemy]);
        spawnedEnemies.Add(spawnedEnemy);
        spawnedEnemy.transform.position = _spawnpoints[Random.Range(0, _spawnpoints.Count)].position;
        spawnedEnemy.transform.SetParent(_enemyParentObject);
    }
}
