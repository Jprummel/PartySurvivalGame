using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private PlayerCharacter _player;

    public delegate void InputDelegate();
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

    }
}
