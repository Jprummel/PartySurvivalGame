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
<<<<<<< HEAD
            StartCoroutine(PlayAnim());

            //attack checks for collision with player or enemy
=======
            //StartCoroutine(PlayAnim());
            StartCoroutine(HitEffect());
>>>>>>> origin/master
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

<<<<<<< HEAD
    void KnockBack(float power, Character source)
    {
        Vector2 forcePos = transform.position - source.transform.position;
        Vector2 clampedPos = forcePos;
        clampedPos = new Vector2(Mathf.Clamp(clampedPos.x, -0.75f, 0.75f), Mathf.Clamp(clampedPos.y, -0.75f, 0.75f));

        _rgb2d.AddForce(power * (clampedPos), ForceMode2D.Impulse);
    }

    IEnumerator PlayAnim()
=======

    IEnumerator HitEffect()
    {
        float duration = 1;
        float smoothness = 0.01f;

        float _progress = 0;

        //_spriteRenderer.color = Color.Lerp(_defaultColor,_hitColor,Time.deltaTime * 5);

        //yield return null;
        while (_progress < 1)
        {
            _spriteRenderer.color = Color.Lerp(_defaultColor, _hitColor,_progress * 5);
            Debug.Log(_spriteRenderer.color);
            _progress += Time.deltaTime;
            yield return new WaitForSeconds(smoothness);
        }/*

        yield return new WaitForSeconds(0.02f);
        while(_progress > 0)
        {
            _spriteRenderer.color = Color.Lerp(_hitColor, _defaultColor, _progress * 5);
            _progress -= Time.deltaTime;
            yield return new WaitForSeconds(smoothness);
        }*/
    }

    /*IEnumerator PlayAnim()
>>>>>>> origin/master
    {
        _animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Hit", false);
<<<<<<< HEAD
    }

    IEnumerator RemoveVelocity()
    {
        yield return new WaitForSeconds(0.05f);
        _rgb2d.velocity = Vector2.zero;
    }
=======
    }*/
>>>>>>> origin/master
}
