using UnityEngine;

public class CharacterSelectInput : MonoBehaviour {

    [SerializeField]private int _playerID;
    [SerializeField]private MapSelection _mapSelection;
    private SceneLoader _sceneLoader;
    private CharacterSelect _characterSelect;
    private CharacterSelectUI _characterSelectUI;
    private CharacterSelectPlayers _characterSelectPlayers;
    private CharacterSelectPrefabs _selectPrefab;
    
    private float _inputDelay;
    private float _inputDelayMaxTime = 0.2f;

    public int PlayerID { get { return _playerID; } }

    private bool _isSelectingCharacter;
    private bool _isJoining;

	void Start () {
        _selectPrefab = GetComponentInParent<CharacterSelectPrefabs>();
        _characterSelectPlayers = GameObject.FindGameObjectWithTag(Tags.CHARACTERSELECTOBJECT).GetComponent<CharacterSelectPlayers>();
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
        _characterSelect = GetComponent<CharacterSelect>();
        _characterSelectUI = GetComponent<CharacterSelectUI>();
	}

    private void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if (_characterSelect.CharacterSelectState)
        {
            if (_inputDelay <= 0)
            {
                if (!_characterSelectPlayers.ReadyToStart)
                {
                    ProgressThroughSelect();
                    BacktrackThroughSelect();
                    if (_characterSelect.PlayerIsActive) // If player is active but not ready & input delay timer is zero
                    {
                        if (!_characterSelect.PlayerIsReady)
                        {
                            NextCharacter();
                            PreviousCharacter();
                        }
                    }
                }
                if (_characterSelectPlayers.ReadyToStart)
                {
                    StartGame();
                    BacktrackThroughSelect();
                }
            }
            InputDelayTimer();
        }
    }

    void InputDelayTimer()
    {
        if (_inputDelay >= 0) //Input delay timer to prevent weird things happening with inputs
        {
            _inputDelay -= Time.deltaTime;
        }
    }

    void ProgressThroughSelect()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            if (!_isSelectingCharacter)
            {
                _characterSelectUI.ToggleJoinGameImage(false);
                _characterSelectUI.SelectedCharacterVisuals();
                _characterSelect.JoinGame();
                _inputDelay = _inputDelayMaxTime;
                _isSelectingCharacter = true;
            }else
            {
                _selectPrefab.SelectCharacter(_characterSelectUI.SelectedCharacterNumber, _playerID);
                _characterSelect.ReadyUp();
                _inputDelay = _inputDelayMaxTime;
            }
        }
    }

    public void StartGame()
    {
        if (Input.GetButtonDown(InputAxes.START + _playerID))
        {
            _sceneLoader.ChangeScene(_mapSelection.SelectedMap);
            _inputDelay = _inputDelayMaxTime;
        }
    }

    void BacktrackThroughSelect()
    {
        if(Input.GetButtonDown(InputAxes.XBOX_B + _playerID))
        {
            if (_characterSelect.PlayerIsActive && !_characterSelect.PlayerIsReady)
            {
                _characterSelectUI.ToggleJoinGameImage(true);
                _characterSelectUI.DisablePortraitsAndNames();
                _characterSelect.LeaveGame();
                _characterSelectUI.SelectedCharacterNumber = 0;
                _inputDelay = _inputDelayMaxTime;
                _isSelectingCharacter = false;
            }
            else if(_characterSelect.PlayerIsActive && _characterSelect.PlayerIsReady)
            {
                DeselectCharacter();
                _characterSelect.UnReady();
            }
        }
    }

    public void DeselectCharacter()
    {
        if(Input.GetButtonDown(InputAxes.XBOX_B + _playerID))
        {
            _selectPrefab.DeselectCharacter();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    public void NextCharacter()
    {
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) > 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerID) > 0)
        {
            if(_characterSelectUI.SelectedCharacterNumber < _characterSelectUI.SelectionPortraits.Count - 1)
            {
                _characterSelectUI.SelectedCharacterNumber++;
            }
            else if (_characterSelectUI.SelectedCharacterNumber == _characterSelectUI.SelectionPortraits.Count - 1)
            {
                _characterSelectUI.SelectedCharacterNumber = 0;
            }
            _characterSelectUI.SelectedCharacterVisuals();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    public void PreviousCharacter()
    {
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) < 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerID) < 0)
        {
            if (_characterSelectUI.SelectedCharacterNumber > 0)
            {
                _characterSelectUI.SelectedCharacterNumber--;
            }
            else if (_characterSelectUI.SelectedCharacterNumber == 0)
            {
                _characterSelectUI.SelectedCharacterNumber = _characterSelectUI.SelectionPortraits.Count - 1;
            }
            _characterSelectUI.SelectedCharacterVisuals();
            _inputDelay = _inputDelayMaxTime;
        }
    }
}