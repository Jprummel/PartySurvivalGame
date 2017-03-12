using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverScreenInputs : MonoBehaviour {

    [SerializeField]private StandaloneInputModule _inputs;
    private PlayerCharacter _playerInControl;

	void Start () {
        _playerInControl = PlayerParty.Players[0].GetComponent<PlayerCharacter>();
        SetInputs();
	}

    void SetInputs()
    {
        //Sets input for the game over screen
        _inputs.horizontalAxis = InputAxes.LEFT_JOYSTICK_X + _playerInControl.PlayerID;
        _inputs.verticalAxis = InputAxes.LEFT_JOYSTICK_Y + _playerInControl.PlayerID;
        _inputs.submitButton = InputAxes.XBOX_A + _playerInControl.PlayerID;
        _inputs.cancelButton = InputAxes.XBOX_B + _playerInControl.PlayerID;
    }
}
