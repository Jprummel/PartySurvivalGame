//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]private float _moveSpeed;
                    private Enemy _enemy;
                    private Quaternion _rotation;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

	void Update () {
        Move();
        transform.rotation = _rotation;
	}

    void Move()
    {
        if(_enemy.DistToPlayer > _enemy.AttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, _enemy.closestTarget, _moveSpeed * Time.deltaTime);
            if (transform.position.x > _enemy.closestTarget.x)
            {
                _rotation.y = 180;
            }
            else if (transform.position.x < _enemy.closestTarget.x)
            {
                _rotation.y = 0;
            }
        }
    }
}
