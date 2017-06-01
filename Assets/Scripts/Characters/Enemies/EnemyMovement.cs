//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Enemy _enemy;
    private EnemyTargetting _enemyTargetting;
    private Quaternion _rotation;
    private Rigidbody2D _rgb2d;
    private bool _hasDirection;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTargetting = GetComponent<EnemyTargetting>();
        _rgb2d = GetComponent<Rigidbody2D>();
    }

	void Update () {
        if (!_enemy.IsDead && _enemyTargetting.Target != null && _enemy.CanMove)
        {
            //MoveToPlayer();
            transform.rotation = _rotation;
        }
	}

    /*void MoveToPlayer()
    {
            float distance = Vector2.Distance(transform.position, _enemyTargetting.Target.transform.position);

            if (distance > _enemy.AttackRange)
            {          
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
    }*/
}
