using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerCharacter _player;
    private PlayerScriptCollector _playerScripts;
    private Rigidbody2D _rgb2d;
    private Quaternion _rotation;
    private Vector2 _direction;

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
        _playerScripts = GetComponent<PlayerScriptCollector>();
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
            if (!_playerScripts.PlayerAttack.IsAttacking)
            {
                _player.UpperBodyAnimator.SetBool("IsWalking", true);//Test
            }
            _player.LowerBodyAnimator.SetBool("IsWalking", true);//Test
        }
        else
        {
            _player.UpperBodyAnimator.SetBool("IsWalking", false);//Test
            _player.LowerBodyAnimator.SetBool("IsWalking", false);//Test
        }
    }
}