using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public delegate void InputDelegate();
    public delegate void MovementDelegate(Vector2 movementVector);
    public static event MovementDelegate MovementInput;
    public static event InputDelegate AttackInput;
    public static event InputDelegate AbillityInput;

    void Update()
    {
        /*if (Input.GetButtonDown(InputAxes.XBOX_X) && AttackInput != null)
        {
            AttackInput();
        }*/

        if (MovementInput != null && Input.GetAxis(InputAxes.LEFT_JOYSTICK_X) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y) != 0)
        {
            MovementInput(new Vector2(Input.GetAxis(InputAxes.LEFT_JOYSTICK_X),Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y)));
        }
    }
}
