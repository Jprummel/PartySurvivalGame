using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerCharacter _player;
    private Rigidbody2D _rgb2d;
    private Quaternion _rotation;
    private Vector2 _direction;

    void Awake()
    {
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

    private void PlayAnimation(Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            _player.UpperBody.AnimationName = SpineAnimationNames.WALK + _player.MoveStateName;
            _player.LowerBody.AnimationName = SpineAnimationNames.WALK + _player.MoveStateName;
        }
        else if(_player.MoveStateName != null)
        {

            _player.UpperBody.AnimationName = SpineAnimationNames.IDLE + _player.MoveStateName;
            _player.LowerBody.AnimationName = SpineAnimationNames.IDLE + _player.MoveStateName;
        }
    }
}