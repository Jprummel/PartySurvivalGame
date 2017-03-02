using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    [SerializeField]protected int _playerID;

    private GameObject _hitBox;
    protected float _gold;
    protected int _score;

    public float CurrentDamageCost { get; set; }
    public float CurrentHealthCost { get; set; }
    public float CurrentMoveSpeedCost { get; set; }

    public int DamageLevel { get; set; }

    public int HealthLevel { get; set; }

    public int MoveSpeedLevel { get; set; }

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
        _animator.SetBool("isDead", true);
        _currentState = PlayerState.DEAD;
        yield return new WaitForSeconds(1);
    }

    void BecomeEnemy()
    {
        _currentState = PlayerState.ENEMY;
        this.tag = Tags.ENEMY;
    }

    public void DealDamage(float multiplier, GameObject target)
    {
        StartCoroutine(EnableHitbox(0.5f));
        float damage = Damage * multiplier;
        ExecuteEvents.Execute<IDamageable>(target, null, (x, y) => x.TakeDamage(damage));
    }

    IEnumerator EnableHitbox(float duration)
    {
        if (!_hitBox.active)
        {
            yield return new WaitForSeconds(0.1f);
            _hitBox.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _hitBox.SetActive(false);
        }


    }

}
