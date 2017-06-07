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

    //Scale factors (when player turns into an enemy)
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
        _warningPlayer = GameObject.FindGameObjectWithTag(Tags.WARNINGOBJECT).GetComponent<PlayerDiedWarning>();
        _upgradeCosts = GetComponent<PlayerUpgradeCosts>();
        base.Awake();
        _respawn = GameObject.FindWithTag(Tags.PLAYERPARTY).GetComponent<Respawn>();
    }

    protected virtual void Start()
    {
        switch (_playerID)
        {
            case 1:
                _upperBodySkeleton.skeleton.SetSkin(SpineSkinNames.ORANGE);
                break;
            case 2:
                _upperBodySkeleton.skeleton.SetSkin(SpineSkinNames.BLUE);
                break;
            case 3:
                _upperBodySkeleton.skeleton.SetSkin(SpineSkinNames.GREEN);
                break;
            case 4:
                _upperBodySkeleton.skeleton.SetSkin(SpineSkinNames.PURPLE);
                break;
            default:
                _upperBodySkeleton.skeleton.SetSkin(SpineSkinNames.ORANGE);
                break;
        }
    }

    protected override void Update()
    {
        base.Update();
        if(CurrentHealth <= 0 && !_isDead)
        {
            StartCoroutine(DeathRoutine());
        }

        SetGoldValue();
    }

    void SetGoldValue()
    {
        if (this.tag == Tags.PLAYER)
        {
            _goldValue = 10000 + (GameInformation.Wave * 250);
        }
        else if (this.tag == Tags.ENEMY)
        {
            _goldValue = 750;
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
        _upperBodySkeleton.AnimationState.SetAnimation(0, SpineAnimationNames.DEATH + _moveStateName,false);
        _lowerBodySkeleton.AnimationState.SetAnimation(0, SpineAnimationNames.DEATH + _moveStateName, false);
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
        _movementSpeed = 4;
        HUD.SetNewHealthBar();
        this.gameObject.layer = LayerMask.NameToLayer("DeadPlayer");
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
    }
}