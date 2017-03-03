using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    [SerializeField]protected int _playerID;

    private GameObject _hitBox;
    protected float _gold;
    protected int _score;

    private float _currrentDamageCost = 500;
    private float _currentHealthCost = 500;
    private float _currentMoveSpeedCost = 500;

    public float CurrentDamageCost 
    {
        get { return _currrentDamageCost; }
        set { _currrentDamageCost = value; }
    }
    public float CurrentHealthCost 
    {
        get { return _currentHealthCost; }
        set { _currentHealthCost = value; }
    }
    public float CurrentMoveSpeedCost
    {
        get { return _currentMoveSpeedCost; }
        set { _currentMoveSpeedCost = value; }
    }

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

    public float Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    void Awake()
    {
        _hitBox = transform.GetChild(0).gameObject;
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
        Debug.Log("ded");
        _animator.SetBool("isDead", true);
        _currentState = PlayerState.DEAD;
        yield return new WaitForSeconds(1);
    }

    void BecomeEnemy()
    {
        _currentState = PlayerState.ENEMY;
        this.tag = Tags.ENEMY;
    }

    public void DealDamage(float multiplier, List<GameObject> target)
    {
        StartCoroutine(EnableHitbox(0.2f));
        StartCoroutine(AttackTargets(target));
    }

    IEnumerator EnableHitbox(float duration)
    {
        if (!_hitBox.active)
        {
            yield return new WaitForSeconds(0.1f);
            _hitBox.SetActive(true);
            yield return new WaitForSeconds(duration);
            _hitBox.SetActive(false);
        }
    }

    IEnumerator AttackTargets(List<GameObject> target)
    {
        //float damage = Damage * multiplier;
        //hitbox duration
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < target.Count; i++)
        {
            ExecuteEvents.Execute<IDamageable>(target[i], null, (x, y) => x.TakeDamage(Damage));
        }
    }
}