//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]private float _moveSpeed;
                    private Enemy _enemy;
    private EnemyTargetting _enemyTargetting;
                    private Quaternion _rotation;

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTargetting = GetComponentInChildren<EnemyTargetting>();
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
                transform.position = Vector2.MoveTowards(transform.position, _enemyTargetting.Target.transform.position, _moveSpeed * Time.deltaTime);
                if (transform.position.x > _enemyTargetting.Target.transform.position.x)
                {
                    _rotation.y = 180;
                }
                else if (transform.position.x < _enemyTargetting.Target.transform.position.x)
                {
                    _rotation.y = 0;
                }
            }
        }
    }
}
