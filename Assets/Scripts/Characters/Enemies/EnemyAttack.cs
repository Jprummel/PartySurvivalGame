using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    Enemy _enemy;
    EnemyTargetting _enemyTargetting;
    private bool _readyToAttack = true;

    void Awake() {
        _enemy = GetComponent<Enemy>();
        _enemyTargetting = GetComponentInChildren<EnemyTargetting>();
    }

    void Update() {
        if (!_enemy.IsDead)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (_enemyTargetting.Target != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTargetting.Target.transform.position);
            if (distance <= _enemy.AttackRange)
            {
                if (_readyToAttack)
                {
                    _readyToAttack = false;
                    StartAttack();
                }
            }
        }

    }

    private void StartAttack()
    {
        _enemy.UpperBodyAnimator.SetInteger("AttackState", 1);
    }

    public void FinishAttack()
    {
        _readyToAttack = true;
    }

    public void FinishAttackAnimation()
    {
        _enemy.UpperBodyAnimator.SetInteger("AttackState", 0);
    }
}
