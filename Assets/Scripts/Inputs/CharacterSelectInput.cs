using UnityEngine;

public class CharacterSelectInput : MonoBehaviour {

    [SerializeField]private int _playerID;
    [SerializeField]private MapSelection _mapSelection;
    private SceneLoader _sceneLoader;
    private CharacterSelect _characterSelect;
    private CharacterSelectUI _characterSelectUI;
    private ShowCharacterInfo _characterInfo;
    private CharacterSelectPrefabs _selectPrefab;

    private float _inputDelay;
    private float _inputDelayMaxTime = 0.2f;
    public float InputDelay
    {
        get { return _inputDelay; }
        set { _inputDelay = value; }
    }

    public int PlayerID { get { return _playerID; } }

	void Start () {
        _selectPrefab       = GetComponentInParent<CharacterSelectPrefabs>();
        _sceneLoader        = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
        _characterSelect    = GetComponent<CharacterSelect>();
        _characterSelectUI  = GetComponent<CharacterSelectUI>();
        _characterInfo      = GetComponent<ShowCharacterInfo>();
	}

    private void Update()
    {
        InputDelayTimer();
    }

    void InputDelayTimer()
    {
        if (_inputDelay > 0) //Input delay timer to prevent weird things happening with inputs
        {
            _inputDelay -= Time.deltaTime;
        }
    }

    public void JoinGame()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            _characterSelect.JoinGame();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    public void SelectCharacter(int selectedprefab, int playerID)
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            _selectPrefab.SelectCharacter(selectedprefab,playerID);
            _characterSelect.ReadyUp();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    public void ShowPlayerInfo()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_Y + _playerID))
        {
            _characterInfo.ToggleDescription();
            _inputDelay = _inputDelayMaxTime;
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
    public void LeaveGame()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_B + _playerID))
        {
            _selectPrefab.DeselectCharacter();
            _characterSelect.LeaveGame();
            _inputDelay = _inputDelayMaxTime;
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
            _inputDelay = _inputDelayMaxTime;
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
            _inputDelay = _inputDelayMaxTime;
        }
    }
}
