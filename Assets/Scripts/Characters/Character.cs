using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour, IDamageable {

    //Editor Values
    [SerializeField]protected string    _name;
    [SerializeField]protected float     _movementSpeed;
    [SerializeField]protected float     _maxHealth;
    [SerializeField]protected float     _damage;
    [SerializeField]protected float     _attackRange;
    [SerializeField]protected float     _attackSpeed;
    [SerializeField]protected float     _goldValue;
    [SerializeField]protected float     _currentHealth;

    private GameObject _lastSource;

    protected bool _isDead;
    protected bool _canMove;
    protected Ranking _ranking;
    protected CharacterSoundFX _soundEffects;
    protected Rigidbody2D _rgb2d;
    private Sequence _giveGold;

    //Visuals
    protected Animator _animator;
    protected float _hitEffectSpeed = 5;
    protected SpriteRenderer _spriteRenderer;
    protected Color _defaultColor;
    protected Color _hitColor;
    protected bool _invincible;

    //Getters & Setters
    public float GoldValue
    {
        get { return _goldValue; }
        set { _goldValue = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float AttackRange
    {
        get { return _attackRange; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
    }

    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    public bool Invincible
    {
        get { return _invincible; }
        set { _invincible = value; }
    }

    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    public Animator CharacterAnimator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    public CharacterSoundFX SoundEffects
    {
        get { return _soundEffects; }
        set { _soundEffects = value; }
    }

    public Rigidbody2D RGB2D
    {
        get { return _rgb2d; }
    }

    protected virtual void Awake()
    {
        _giveGold       = DOTween.Sequence();
        _ranking        = GameObject.FindGameObjectWithTag(Tags.RANKTRACKER).GetComponent<Ranking>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _soundEffects   = GetComponent<CharacterSoundFX>();
        _animator       = GetComponent<Animator>();    //Gets the characters animator
        _rgb2d          = GetComponent<Rigidbody2D>();
        _defaultColor   = _spriteRenderer.color;
        _hitColor       = new Color(1,0.6f,0.6f);
        _canMove        = true;
        _currentHealth  = _maxHealth;             //Sets the characters current health to its max health on spawn
    }

    public void TakeDamage(Character damageSource)
    {   //checks if source of damage is not the last enemy/player who dealt damage
        if(damageSource.gameObject != _lastSource)
        {
            if (_currentHealth > 0)
            {
                //attack checks for collision with player or enemy
                if (this.gameObject.tag == Tags.PLAYER & damageSource.gameObject.tag == Tags.ENEMY & !_invincible)
                {
                    StartCoroutine(HitEffect());
                    _soundEffects.PlayHitAudio();
                    _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
                    KnockBack(10, damageSource, 0.1f);
                }
                if (this.gameObject.tag == Tags.ENEMY & damageSource.gameObject.tag == Tags.PLAYER)
                {
                    StartCoroutine(HitRoutine());
                    StartCoroutine(HitEffect());
                    _soundEffects.PlayHitAudio();
                    _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
                                                             //knockback value/1000
                    KnockBack(0.002f, damageSource, 0.15f);
                    if (_currentHealth <= 0)
                    {
                        //give gold
                        foreach (PlayerCharacter player in PlayerParty.PlayerCharacters)
                        {
                            //lerp player gold
                            player.EndLerpGold += this.GoldValue;
                            _giveGold.Append(DOTween.To(()=> player.Gold,x => player.Gold = x, player.EndLerpGold, 0.5f));
                            player.TotalGoldEarned += this.GoldValue;
                        }
                        PlayerCharacter source = damageSource.GetComponent<PlayerCharacter>();
                        source.EndLerpGold += this.GoldValue;
                        DOTween.To(() => source.Gold, x => source.Gold = x, source.EndLerpGold, 0.5f);
                        source.TotalGoldEarned += this.GoldValue;
                        _ranking.UpdateRanks();
                    }
                }
            }//wait 0.25s to be able to get hit again by the same target
            StartCoroutine(ResetDamageSource(damageSource.gameObject));
        }
    }

    void KnockBack(float power, Character source, float stunTime)
    {
        _canMove = false;
        Vector2 forcePos = transform.position - source.transform.position;
        Vector2 clampedPos = forcePos.normalized;
        clampedPos = new Vector2(Mathf.Clamp(clampedPos.x, -1f, 1f), Mathf.Clamp(clampedPos.y, -0.5f, 0.5f));
        //set min/max value to prevent character being knocked back to china.
        _rgb2d.AddForce(power * (clampedPos), ForceMode2D.Impulse);
        StartCoroutine(RemoveVelocity(stunTime));
    }


    IEnumerator HitEffect()
    {
        float duration = 0.33f;
        float smoothness = 0.01f;
        float _progress = 0;

        if(_spriteRenderer.color == _defaultColor)
        {
            while (_progress < duration)
            {
                _spriteRenderer.color = Color.Lerp(_defaultColor, _hitColor, _progress * 5);
                _progress += Time.deltaTime;
                yield return new WaitForSeconds(smoothness);
            }
            //go back to standard color when the player is at the end of the hit color animation
            while (_progress >= duration)
            {
                _spriteRenderer.color = Color.Lerp(_hitColor, _defaultColor, _progress * 5);
                _progress -= duration;
                yield return new WaitForSeconds(smoothness);
            }
        }
    }

    IEnumerator ResetDamageSource(GameObject source)
    {
        _lastSource = source;
        yield return new WaitForSeconds(0.3f);
        _lastSource = null;
    }

    IEnumerator HitRoutine()
    {
        _animator.SetBool("Hit", true);
        _canMove = false;
        yield return new WaitForSeconds(0.5f);
        _canMove = true;
        _animator.SetBool("Hit",false);
    }

    IEnumerator RemoveVelocity(float stunTime)
    {
        //stop the character from knockback
        yield return new WaitForSeconds(0.08f);
        _rgb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        _canMove = true;
    }
}
