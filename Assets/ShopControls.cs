using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopControls : MonoBehaviour {

    private ShopDisplay _display;
    private EventSystem _eventSystem;
    private StandaloneInputModule _inputs;

	void Start () {
        _display = GetComponent<ShopDisplay>();
        _inputs = GetComponentInChildren<StandaloneInputModule>();

        SetInputs();
	}

    void SetInputs()
    {
        _inputs.horizontalAxis = InputAxes.LEFT_JOYSTICK_X + _display.MatchingPlayer.PlayerID;
        _inputs.submitButton = InputAxes.XBOX_A + _display.MatchingPlayer.PlayerID;
        _inputs.cancelButton = InputAxes.XBOX_B + _display.MatchingPlayer.PlayerID;
    }
}
