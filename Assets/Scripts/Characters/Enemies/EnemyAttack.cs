//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAttack : MonoBehaviour {

    Enemy _enemy;
    private float _attackCooldown;

	void Awake () {
        _enemy = GetComponent<Enemy>();
	}
	
	void Update () {
        Attack();
	}

    void Attack()
    {
        if(_enemy.DistToPlayer <= _enemy.AttackRange)
        {
            if(_attackCooldown >= _enemy.AttackSpeed)
            {
                ExecuteEvents.Execute<IDamageable>(_enemy.Target, null, (x, y) => x.TakeDamage(_enemy.Damage));
            }
        }
    }
}
