using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterAnimations _animations;
    private PlayerCharacter _player;
    private Rigidbody2D _rgb2d;
    private Quaternion _rotation;
    private Vector2 _direction;

    void Awake()
    {
        _animations = GetComponent<CharacterAnimations>();
        _player = GetComponent<PlayerCharacter>();
    }

	void Start () {
        _rgb2d = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector2 moveDir)
    {
        transform.rotation = _rotation;
        _rgb2d.MovePosition(_rgb2d.position + moveDir * _player.MovementSpeed * Time.deltaTime);
        PlayAnimation(moveDir);
    }

    void PlayAnimation(Vector2 moveDir)
    {
        if(moveDir != Vector2.zero)
        {
            _animations.MoveAnimation();
        }
        else
        {
            _animations.IdleAnimation();
        }
    }
}