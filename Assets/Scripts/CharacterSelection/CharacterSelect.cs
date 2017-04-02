        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    //Script imports
    [SerializeField]private SelectionScreen _selectionScreen;
    private CharacterSelectPlayers _characterSelectPlayers;
    private ShowCharacterInfo _characterInfo;
    private CharacterSelectUI _characterSelectUI;
    private CharacterSelectInput _input;

    //List of selectable characters
    [SerializeField]private List<GameObject> _characters = new List<GameObject>();
    //UI
    [SerializeField]private GameObject _joinGameImage;
    [SerializeField]private GameObject _readyText;

    private bool _characterSelectState;
    private bool _playerIsActive;
    private bool _ready;
    //Inputs
    private float _inputDelay;
    private float _inputDelayMaxTime = 0.2f;
    //Selected Character    
    private int _selectedCharacterNumber = 0;
    private GameObject _selectedCharacterPrefab;
    private PlayerCharacter _selectedCharacter;
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
        _characterInfo = GetComponent<ShowCharacterInfo>();
        _characterSelectPlayers = GameObject.FindGameObjectWithTag(Tags.CHARACTERSELECTOBJECT).GetComponent<CharacterSelectPlayers>();
        _characterSelectUI = GetComponent<CharacterSelectUI>();
        _input = GetComponent<CharacterSelectInput>();

        _characterInfo.CharacterDescription(0);
    }

    void Update()
    {
        if (_characterSelectState)
        {
            _input.JoinGame();
            _input.LeaveGame();
            if (_playerIsActive && _inputDelay <= 0) // If player is active but not ready & input delay timer is zero
            {
                _input.ShowPlayerInfo();
                if (!_ready)
                {
                    _input.NextCharacter();
                    _input.PreviousCharacter();
                    _input.SelectCharacter();
                }
            }
            if (_characterSelectPlayers.ReadyToStart)
            {
                _input.ShowPlayerInfo();
                _input.StartGame();
            }
            InputDelayTimer();
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
            _inputDelay = _inputDelayMaxTime;
        }
    }

    public void LeaveGame()
    {
        if (_playerIsActive && _ready) //If player is active and ready , unready
        {
            PlayerParty.Players.Remove(_selectedCharacterPrefab);
            PlayerParty.PlayerCharacters.Remove(_selectedCharacter);
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
            _selectedCharacterNumber = 0; //if player wants to rejoing, start on knight character again
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
        _inputDelay = _inputDelayMaxTime; //resets the input delay
    }

    void InputDelayTimer()
    {
        if (_inputDelay > 0) //Input delay timer to prevent weird things happening with inputs
        {
            _inputDelay -= Time.deltaTime;
        }
    }

    public void SelectCharacter()
    {
        _selectedCharacterPrefab = _characters[_selectedCharacterNumber];
        PlayerParty.Players.Add(_selectedCharacterPrefab);
        _selectedCharacter = _characters[_selectedCharacterNumber].GetComponent<PlayerCharacter>();
        _selectedCharacter.PlayerID = _input.PlayerID; //Sets selected characters id equal to the players id who selected him
        _ready = true;
        _readyText.SetActive(true);
        _characterSelectPlayers.ReadyPlayers++;
        _inputDelay = _inputDelayMaxTime;
    }
}
