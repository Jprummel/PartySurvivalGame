//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
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
        
        //Makes the characters sprite face his move direction 
        if (moveDir.x < 0)
        {
            _rotation.y = 180;
        }
        else if (moveDir.x > 0)
        {
            _rotation.y = 0;
        }
    }

    private void PlayAnimation(Vector2 dir)
    {
        if(dir != Vector2.zero)
        {
            _player.CharacterAnimator.SetBool("IsMoving", true);
        }
        else
        {
            _player.CharacterAnimator.SetBool("IsMoving", false);
        }
    }
}
