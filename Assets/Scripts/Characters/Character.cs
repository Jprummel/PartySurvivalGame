using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable {

    //Editor Values
    [SerializeField]protected string    _name;
    [SerializeField]protected float     _movementSpeed;
    [SerializeField]protected float     _maxHealth;
    [SerializeField]protected float     _damage;
    [SerializeField]protected float     _attackRange;
    [SerializeField]protected float     _attackSpeed;
    protected bool _isDead;
    private Rigidbody2D _rgb2d;
    [SerializeField]protected float _currentHealth;
    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;
    protected float _hitEffectSpeed = 5;
    protected Color _defaultColor;
    protected Color _hitColor;

    //Getters & Setters
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
        set { _attackRange = value; }
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

    public Animator CharacterAnimator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        _hitColor = new Color(1,0.6f,0.6f);
        _animator = GetComponent<Animator>();    //Gets the characters animator
        _currentHealth = _maxHealth;             //Sets the characters current health to its max health on spawn
        _rgb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(Character damageSource)
    {
        if (_currentHealth > 0)
        {
            //attack checks for collision with player or enemy
            //StartCoroutine(PlayAnim());
            if(_spriteRenderer.color == _defaultColor)
            {
                StartCoroutine(HitEffect());
            }

            if (this.gameObject.tag == Tags.PLAYER & damageSource.gameObject.tag == Tags.ENEMY)
            {
                _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
                KnockBack(5, damageSource);
            }
            if(this.gameObject.tag == Tags.ENEMY && damageSource.gameObject.tag == Tags.PLAYER)
            {
                _currentHealth -= damageSource.Damage;   //Reduces currenthealth by the amount of damage the source of damage has
                KnockBack(20, damageSource);
                if (_currentHealth <= 0)
                {
                    //give gold
                    StartCoroutine(RemoveVelocity());
                    PlayerCharacter source = damageSource.GetComponent<PlayerCharacter>();
                    Enemy enemy = GetComponent<Enemy>();
                    source.Gold += enemy.GoldValue;
                }
            }
        }
    }

    void KnockBack(float power, Character source)
    {
        Vector2 forcePos = transform.position - source.transform.position;
        Vector2 clampedPos = forcePos.normalized;
        clampedPos = new Vector2(Mathf.Clamp(clampedPos.x, -0.5f, 0.5f), Mathf.Clamp(clampedPos.y, -0.5f, 0.5f));
        //set min/max value to prevent charachter being knocked back to china.
        _rgb2d.AddForce(power * (clampedPos), ForceMode2D.Impulse);
    }


    IEnumerator HitEffect()
    {
        float duration = 1;
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

    /*IEnumerator PlayAnim()
    {
        _animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Hit", false);
    }*/

    IEnumerator RemoveVelocity()
    {
        //stop the character from knockback
        yield return new WaitForSeconds(0.05f);
        _rgb2d.velocity = Vector2.zero;
    }
}
