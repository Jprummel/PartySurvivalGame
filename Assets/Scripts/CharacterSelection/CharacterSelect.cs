using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    //Script imports
    [SerializeField]private SelectionScreen _selectionScreen;
    private CharacterSelectPlayers          _characterSelectPlayers;
    private ShowCharacterInfo               _characterInfo;
    private CharacterSelectUI               _characterSelectUI;
    private CharacterSelectInput            _input;
    
    //UI
    [SerializeField]private GameObject _joinGameImage;
    [SerializeField]private GameObject _readyText;

    private bool _characterSelectState;
    private bool _playerIsActive;
    private bool _ready;

    //Selected Character    
    private int             _selectedCharacterNumber = 0;
    public int SelectedCharacterNumber
    {
        get { return _selectedCharacterNumber; }
        set { _selectedCharacterNumber = value; }
    }

    [SerializeField]private GameObject _mapSelectionScreen;
    [SerializeField]private GameObject _characterSelectionScreen;

    public bool CharacterSelectState
    {
        get { return _characterSelectState; }
        set { _characterSelectState = value; }
    }

    void Start()
    {
        _characterInfo          = GetComponent<ShowCharacterInfo>();
        _characterSelectPlayers = GameObject.FindGameObjectWithTag(Tags.CHARACTERSELECTOBJECT).GetComponent<CharacterSelectPlayers>();
        _characterSelectUI      = GetComponent<CharacterSelectUI>();
        _input                  = GetComponent<CharacterSelectInput>();

        _characterInfo.CharacterDescription(0);
    }

    void Update()
    {
        if (_characterSelectState)
        {
            _input.JoinGame();
            _input.LeaveGame();
            if (_playerIsActive && _input.InputDelay <= 0) // If player is active but not ready & input delay timer is zero
            {
                _input.ShowPlayerInfo();
                if (!_ready)
                {
                    _input.NextCharacter();
                    _input.PreviousCharacter();
                    _input.SelectCharacter(_selectedCharacterNumber,_input.PlayerID);
                }
            }
            if (_characterSelectPlayers.ReadyToStart)
            {
                _input.ShowPlayerInfo();
                _input.StartGame();
            }
        }
    }

    public void JoinGame()
    {
        if (!_playerIsActive)
        {
            _joinGameImage.SetActive(false);
            _characterSelectPlayers._players.Add(this);
            _playerIsActive = true;
            _characterSelectPlayers.ActivePlayers++;
            _characterSelectUI.SelectedCharacterVisuals();
        }
    }

    public void LeaveGame()
    {
        if (_playerIsActive && _ready) //If player is active and ready , unready
        {
            _readyText.SetActive(false);
            _ready = false;
            _characterSelectPlayers.ReadyPlayers--;
        }
        else if (_playerIsActive && !_ready) //If player is active but not ready , set inactive
        {
            _joinGameImage.SetActive(true); //Shows the "Join Game" image
            _playerIsActive = false; //Sets player inactive
            _characterSelectPlayers.ActivePlayers--;        //Reduces the active players
            _characterSelectPlayers._players.Remove(this);  //Removes this player from the character selection player list
            _selectedCharacterNumber = 0; //if player wants to rejoin, start on knight character again
            _characterSelectUI.DisablePortraitsAndNames(); //Deactivates the portraits and names
        }

        if (_characterSelectPlayers.ActivePlayers <= 0)
        {
            StartCoroutine(_selectionScreen.SwitchToMapSelect());
        }
    }

    public void ChangePortraitAndName()
    {
        _characterSelectUI.SelectedCharacterVisuals(); //Changes portrait and nameplate
    }

    public void ReadyUp()
    {
        //Sets the players state to ready in the character selection screen
        _ready = true;
        _readyText.SetActive(true);
        _characterSelectPlayers.ReadyPlayers++;
    }
}