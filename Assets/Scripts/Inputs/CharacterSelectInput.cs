using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectInput : MonoBehaviour {

    [SerializeField]private int _playerID;
    [SerializeField]private MapSelection _mapSelection;
    private SceneLoader _sceneLoader;
    private CharacterSelect _characterSelect;
    private CharacterSelectUI _characterSelectUI;
    private ShowCharacterInfo _characterInfo;

    public int PlayerID { get { return _playerID; } }

	void Start () {
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
        _characterSelect = GetComponent<CharacterSelect>();
        _characterSelectUI = GetComponent<CharacterSelectUI>();
        _characterInfo = GetComponent<ShowCharacterInfo>();
	}

    public void JoinGame()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            _characterSelect.JoinGame();
        }
    }

    public void SelectCharacter()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            _characterSelect.SelectCharacter();
        }
    }

    public void ShowPlayerInfo()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_Y + _playerID))
        {
            _characterInfo.ToggleDescription();
        }
    }

    public void StartGame()
    {
        if (Input.GetButtonDown(InputAxes.START + _playerID))
        {
            _sceneLoader.ChangeScene(_mapSelection.SelectedMap);
        }
    }
    public void LeaveGame()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_B + _playerID))
        {
            _characterSelect.LeaveGame();
        }
    }

    public void NextCharacter()
    {
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) > 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerID) > 0)
        {
            if(_characterSelect.SelectedCharacterNumber < _characterSelectUI.SelectionPortraits.Count - 1)
            {
                _characterSelect.SelectedCharacterNumber++;
            }
            else if (_characterSelect.SelectedCharacterNumber == _characterSelectUI.SelectionPortraits.Count - 1)
            {
                _characterSelect.SelectedCharacterNumber = 0;
            }
            _characterSelect.ChangePortraitAndName();
            _characterInfo.CharacterDescription(_characterSelect.SelectedCharacterNumber);
        }
    }

    public void PreviousCharacter()
    {
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) < 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerID) < 0)
        {
            if (_characterSelect.SelectedCharacterNumber > 0)
            {
                _characterSelect.SelectedCharacterNumber--;
            }
            else if (_characterSelect.SelectedCharacterNumber == 0)
            {
                _characterSelect.SelectedCharacterNumber = _characterSelectUI.SelectionPortraits.Count - 1; //If at the last character go back to the first one
            }
            _characterSelect.ChangePortraitAndName();
            _characterInfo.CharacterDescription(_characterSelect.SelectedCharacterNumber);
        }
    }
}
