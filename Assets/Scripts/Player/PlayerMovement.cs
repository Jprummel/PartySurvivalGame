//( ͡° ͜ʖ ͡°)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private PlayerCharacter _player;
    private bool _gotRB = false;
    private Rigidbody2D _rgb2d;
    [SerializeField]private float _moveSpeed;

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
    }

	void Start () {
        _rgb2d = GetComponent<Rigidbody2D>();
        //ControllerInput.MovementInput += Move;
	}

    void Move(Vector2 moveDir, GameObject player)
    {
        if (!_gotRB)
        {
            _rgb2d = player.gameObject.GetComponent<Rigidbody2D>();
            _gotRB = true;
        }
        _rgb2d.MovePosition(_rgb2d.position + moveDir * _player.MovementSpeed * Time.deltaTime);
    }
}
