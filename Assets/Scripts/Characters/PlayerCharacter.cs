using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    protected int _playerID;

    protected int _gold;
    protected int _score;
    protected enum PlayerState
    {
        ALIVE,
        DEAD,
        ENEMY
    }

    protected PlayerState _currentState;

    public int PlayerID
    {
        get { return _playerID; }
        set { _playerID = value; }
    }

    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    void Death()
    {
        _animator.SetBool("isDead", true);
        _currentState = PlayerState.DEAD;
    }

    void TakeDamage(Character character)
    {
        _currentHealth -= character.Damage;
        if (_currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine()
    {
        _animator.SetBool("isDead", true);
        _currentState = PlayerState.DEAD;
        yield return new WaitForSeconds(1);
    }

    void BecomeEnemy()
    {
        _currentState = PlayerState.ENEMY;
        this.tag = Tags.ENEMY;
    }

    void DealDamage()
    {
        //ExecuteEvents.Execute<IDamageable>(enemy, null, (x, y) => x.TakeDamage(Damage, this));
    }
}
