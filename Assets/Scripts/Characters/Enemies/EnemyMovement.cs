using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    EnemyTargetting _enemyTargetting;

    [SerializeField]private float _moveSpeed;

	// Use this for initialization
	void Awake () {
        _enemyTargetting = GetComponent<EnemyTargetting>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemyTargetting.closestTarget, _moveSpeed * Time.deltaTime);
    }
}
