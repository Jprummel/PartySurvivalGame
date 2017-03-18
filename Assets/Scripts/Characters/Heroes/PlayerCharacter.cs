using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    //Visuals
    [SerializeField]protected Sprite _portrait;
    [SerializeField]private GameObject _deadIndicator;
    private Sprite _startSprite;

    public Sprite Portrait { get { return _portrait; } }

    public PlayerHud HUD { get; set; }

    //Script imports
    private Respawn     _respawn;
    private ChangePortraitColor _portraitColor;

    //Gold
    protected float     _gold;
    protected float     _totalGoldEarned;
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

    public float Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public float TotalGoldEarned
    {
        get { return _totalGoldEarned; }
        set { _totalGoldEarned = value; }
    }

    //Player ID
    [SerializeField]protected int _playerID;
    public int PlayerID
    {
        get { return _playerID; }
        set { _playerID = value; }
    }

    protected override void Awake()
    {
        _gold = 1500;
        PlayerParty.PlayerCharacters.Add(this);
        _portraitColor = GameObject.FindGameObjectWithTag(Tags.PLAYERHUDS).GetComponent<ChangePortraitColor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSprite = _spriteRenderer.sprite;
        base.Awake();
        _respawn = GameObject.FindWithTag("PlayerParty").GetComponent<Respawn>();
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
        _animator.SetInteger("AttackState", 0);
        yield return new WaitForSeconds(1.5f);
        PlayerParty.PlayerCharacters.Remove(this);
        _respawn.deadPlayers.Add(this);
        BecomeEnemy();
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
        this.tag = Tags.ENEMY;
        _portraitColor.SetPortraitHostile(HUD.Portrait);
        _deadIndicator.SetActive(true);
        HUD.SetNewHealthBar();
    }
}