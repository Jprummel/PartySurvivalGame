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
        float distance = Vector2.Distance(transform.position, _enemy.Target.transform.position);
        if (distance <= _enemy.AttackRange)
        {
            if (_readyToAttack)
            {
                _readyToAttack = false;
                StartCoroutine(AttackCooldown());
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        _enemy.CharacterAnimator.SetInteger("AnimationState", 1);
        yield return new WaitForSeconds(_enemy.AttackSpeed / 2);
        ExecuteEvents.Execute<IDamageable>(_enemy.Target, null, (x, y) => x.TakeDamage(_enemy.Damage));
        yield return new WaitForSeconds(_enemy.AttackSpeed / 2);        
        _readyToAttack = true;
        _enemy.CharacterAnimator.SetInteger("AnimationState", 0);
    }
}
