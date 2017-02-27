//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Enemy _enemy;

    [SerializeField]private float _moveSpeed;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

	void Update () {
        Move();
	}

    void Move()
    {
        if(_enemy.DistToPlayer > _enemy.AttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, _enemy.closestTarget, _moveSpeed * Time.deltaTime);
        }
    }
}
