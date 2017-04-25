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

    //Ability
    protected Ability _ability;
    public Ability Ability { get { return _ability; }}
    //Visuals
    [SerializeField]protected Sprite _portrait;
    [SerializeField]private GameObject _deadIndicator;
    private Sprite _startSprite;

    public Sprite Portrait { get { return _portrait; }}
    public PlayerHud HUD { get; set; }

    //Script/Component imports
    private Respawn     _respawn;
    private ChangePortraitColor _portraitColor;
    private PlayerUpgradeCosts _upgradeCosts;
    public PlayerUpgradeCosts UpgradeCosts { get { return _upgradeCosts; }}

    //Gold
    protected float     _gold;
    protected float     _totalGoldEarned;

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
        _isDead = true;
        _canMove = false;
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
        _movementSpeed = 4;
        HUD.SetNewHealthBar();
        this.gameObject.layer = LayerMask.NameToLayer("DeadPlayer");
    }
}