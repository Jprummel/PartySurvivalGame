using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    private Sprite _startSprite;
    [SerializeField]protected int _playerID;
    [SerializeField]protected Sprite _portrait;
    protected float     _gold;
    private float _currrentDamageCost = 500;
    private float _currentHealthCost = 500;
    private float _currentMoveSpeedCost = 500;

    public Sprite Portrait
    {
        get { return _portrait; }
    }

    public PlayerHud HUD { get; set; }

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

    protected override void Awake()
    {
        PlayerParty.PlayerCharacters.Add(this);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSprite = _spriteRenderer.sprite;
        base.Awake();
    }

    void Update()
    {
        if(CurrentHealth <= 0 && !_isDead)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine()
    {
        _isDead = true;
        _animator.SetBool("IsDead", true);
        _currentState = PlayerState.DEAD;
        PlayerParty.PlayerCharacters.Remove(this);
        Respawn.deadPlayers.Add(this);
        BecomeEnemy();
        yield return new WaitForSeconds(1.5f);
        _spriteRenderer.sprite = _startSprite;
        gameObject.SetActive(false);
    }

    public void RestoreHealth()
    {
        CurrentHealth = Mathf.Lerp(CurrentHealth, MaxHealth, 2f);
        _isDead = false;
    }

    void BecomeEnemy()
    {
        _currentState = PlayerState.ENEMY;
        this.tag = Tags.ENEMY;
    }
}