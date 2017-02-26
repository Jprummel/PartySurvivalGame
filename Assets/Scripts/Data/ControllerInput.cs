using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private PlayerCharacter _player;

    public delegate void InputDelegate();
    public delegate void MovementDelegate(Vector2 movementVector,GameObject player);
    public static event MovementDelegate MovementInputP1;
    public static event MovementDelegate MovementInputP2;
    public static event InputDelegate AttackInput;
    public static event InputDelegate AbillityInput;

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        /*if (Input.GetButtonDown(InputAxes.XBOX_X) && AttackInput != null)
        {
            AttackInput();
        }*/

        if (MovementInputP1 != null && Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
        {
            Debug.Log(_player.PlayerID);
            MovementInputP1(new Vector2(Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID),Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID)),PlayerParty.Players[_player.PlayerID-1]);
        }
        if (MovementInputP2 != null && Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
        {
            Debug.Log(_player.PlayerID);
            MovementInputP2(new Vector2(Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID), Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID)),PlayerParty.Players[_player.PlayerID-1]);
        }
    }
}
