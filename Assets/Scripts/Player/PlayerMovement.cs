//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private SpriteRenderer _renderer;
    private PlayerCharacter _player;
    private Rigidbody2D _rgb2d;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerCharacter>();
    }

	void Start () {
        _rgb2d = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector2 moveDir)
    {
        _rgb2d.MovePosition(_rgb2d.position + moveDir * _player.MovementSpeed * Time.deltaTime);
        //Makes the characters sprite face his move direction    
        if (moveDir.x < 0)
        {
            _renderer.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            _renderer.flipX = false;
        }
    }
}
