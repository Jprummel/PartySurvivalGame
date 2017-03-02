using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private PlayerCharacter _player;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_X + _player.PlayerID))
        {
            _playerAttack.Attack();
        }

        if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
        {
            float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID);
            float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID);
            _playerMovement.Move(new Vector2(x, y));
        }
        else
            _playerMovement.Move(new Vector2(0, 0));
    }
}
