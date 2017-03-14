//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]private float _moveSpeed;
    private Enemy _enemy;
    private EnemyTargetting _enemyTargetting;
    private Quaternion _rotation;
    private Rigidbody2D _rgb2d;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTargetting = GetComponentInChildren<EnemyTargetting>();
        _rgb2d = GetComponent<Rigidbody2D>();
    }

	void Update () {
        if (!_enemy.IsDead)
        {
            Move();
            transform.rotation = _rotation;
        }
	}

    void Move()
    {

        if (_enemyTargetting.Target != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTargetting.Target.transform.position);

            if (distance > _enemy.AttackRange)
            {
                Debug.Log("keep moving");
                Vector2 dir = (_enemyTargetting.Target.transform.position - transform.position).normalized * _moveSpeed;
                //transform.position = Vector2.MoveTowards(transform.position, _enemyTargetting.Target.transform.position, _moveSpeed * Time.deltaTime);
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
}
