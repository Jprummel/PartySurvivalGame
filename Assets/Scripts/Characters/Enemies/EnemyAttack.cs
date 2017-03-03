//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAttack : MonoBehaviour {

    Enemy _enemy;
    private bool _readyToAttack = true;

	void Awake () {
        _enemy = GetComponent<Enemy>();
	}
	
	void Update () {
        Attack();
	}

    void Attack()
    {
        if (_enemy.DistToPlayer <= _enemy.AttackRange)
        {
            if (_readyToAttack)
            {
                StartCoroutine(AttackCooldown());
                _readyToAttack = false;
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        _enemy.CharacterAnimator.SetInteger("AnimationState", 1);
        yield return new WaitForSeconds(_enemy.AttackSpeed);
        ExecuteEvents.Execute<IDamageable>(_enemy.Target, null, (x, y) => x.TakeDamage(_enemy.Damage));
        _readyToAttack = true;
        _enemy.CharacterAnimator.SetInteger("AnimationState", 0);
    }
}
