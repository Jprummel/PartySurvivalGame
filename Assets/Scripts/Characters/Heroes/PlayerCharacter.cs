using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character {

    //Attacks
    [SerializeField]protected int _maxLightAttackState;
    protected int _lightAttackState = 1;

    public int MaxLightAttackState { get { return _maxLightAttackState; } }
    public int LightAttackState 
    { 
        get { return _lightAttackState; }
        set { _lightAttackState = value; }
    }

    private bool _isAlly = true;

    public bool IsAlly
    {
        get { return _isAlly; }
        set { _isAlly = value; }
    }

    //Ability
    protected Ability _ability;
    public Ability Ability { get { return _ability; }}
    //Visuals
    [SerializeField]protected Sprite _portrait;
    [SerializeField]private GameObject _deadIndicator;
    [SerializeField]private PlayerDiedWarning _warningPlayer;
    private Sprite _startSprite;

    public Sprite Portrait { get { return _portrait; }}
    public PlayerHud HUD { get; set; }

    //Script/Component imports
    private EnemySpawner _enemySpawner;
    private Respawn     _respawn;
    private ChangePortraitColor _portraitColor;
    private PlayerUpgradeCosts _upgradeCosts;
    public PlayerUpgradeCosts UpgradeCosts { get { return _upgradeCosts; }}

    protected float _damageScaleFactor;
    protected float _healthScaleFactor;

    public float DamageScaleFactor { get { return _damageScaleFactor; } }
    public float HealthScaleFactor { get { return _healthScaleFactor; } }

    //Gold
    protected float     _gold;
    protected float     _totalGoldEarned;
    private float       _endLerpGold;

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

    public float EndLerpGold
    {
        get { return _endLerpGold; }
        set { _endLerpGold = value; }
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
        _endLerpGold = _gold;
        PlayerParty.PlayerCharacters.Add(this);
        _portraitColor = GameObject.FindGameObjectWithTag(Tags.PLAYERHUDS).GetComponent<ChangePortraitColor>();
        _warningPlayer = GameObject.Find("PlayerDiedWarning").GetComponent<PlayerDiedWarning>();
        _upgradeCosts = GetComponent<PlayerUpgradeCosts>();
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
        if (!_isAlly)
        { 
            _enemySpawner.spawnedEnemies.Remove(this.gameObject);
            _enemySpawner._playerEnemies.Remove(this.gameObject);
            _respawn.deadPlayers.Remove(this);
        }
        _isDead = true;
        _canMove = false;
        _animator.SetBool("IsDead", true);
        _animator.SetInteger("AttackState", 0);
        yield return new WaitForSeconds(1.5f);
        if (_isAlly)
        {
            _warningPlayer.WarnPlayers();
        }
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
        _isAlly = false;
        this.tag = Tags.ENEMY;
        _portraitColor.SetPortraitHostile(HUD.Portrait);
        _deadIndicator.SetActive(true);
        _movementSpeed = 4;
        HUD.SetNewHealthBar();
        this.gameObject.layer = LayerMask.NameToLayer("DeadPlayer");
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
    }
}