//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Enemy _enemy;
    private EnemyTargetting _enemyTargetting;
    private Quaternion _rotation;
    private Rigidbody2D _rgb2d;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTargetting = GetComponent<EnemyTargetting>();
        _rgb2d = GetComponent<Rigidbody2D>();
    }

	void Update () {
        if (!_enemy.IsDead && _enemyTargetting.Target != null)
        {
            MoveToPlayer();
            transform.rotation = _rotation;
        }else
        {
            MoveDown();
        }
	}

    void MoveDown()
    {
        float xDir = transform.forward.magnitude;
        if(_rotation.y == 180)
        {
            xDir = -xDir;
        }
        Vector2 dir = new Vector2(-xDir / 2,-3);
        _rgb2d.velocity = dir;
    }

    void MoveToPlayer()
    {
            float distance = Vector2.Distance(transform.position, _enemyTargetting.Target.transform.position);

            if (distance > _enemy.AttackRange)
            {
                Vector2 dir = (_enemyTargetting.Target.transform.position - transform.position).normalized * _enemy.MovementSpeed;
                _rgb2d.velocity = dir;
                if (transform.position.x > _enemyTargetting.Target.transform.position.x)
                {
                    _rotation.y = 180;
                }
                else if (transform.position.x < _enemyTargetting.Target.transform.position.x)
                {
                    _rotation.y = 0;
                }
            }
            else
            {
                _rgb2d.velocity = Vector2.zero;
            }
    }
}
