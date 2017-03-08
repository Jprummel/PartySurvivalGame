using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    [SerializeField]private List<GameObject> _selectionPortraits = new List<GameObject>();
    [SerializeField]private List<GameObject> _selectionNames = new List<GameObject>();
    [SerializeField]private List<GameObject> _characters = new List<GameObject>();
    [SerializeField]private int _playerID;
    private CharacterSelectPlayers _characterSelectPlayers;
    private int _selectedCharacterNumber = 0;
    private bool _playerIsActive;
    private bool _ready;
    private float _inputDelay;
    private float _inputDelayMaxTime = 0.2f;

    public bool PlayerIsActive
    {
        get { return _playerIsActive; }
    }

    public bool PlayerIsReady
    {
        get { return _ready; }
    }

    void Start()
    {
        _characterSelectPlayers = GameObject.FindGameObjectWithTag(Tags.CHARACTERSELECTOBJECT).GetComponent<CharacterSelectPlayers>();
        SelectedCharacterVisuals();
    }

    void Update()
    {
        JoinGame();
        LeaveGame();
        if (_playerIsActive)
        {
            NextCharacter();
            PreviousCharacter();
            SelectCharacter();
        }
        if (_characterSelectPlayers.ReadyToStart)
        {
            StartGame();
        }
        InputDelayTimer();
    }

    void SelectedCharacterVisuals()
    {
        //If i is equal to _selectedCharacterNumber activate the fitting name and portrait
        //If it is not equal, de-activate it
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            if (i == _selectedCharacterNumber)
            { 
                _selectionPortraits[i].SetActive(true); 
            }
            else
            {
                _selectionPortraits[i].SetActive(false);
            }
            
        }

        for (int i = 0; i < _selectionNames.Count; i++)
        {
            if (i == _selectedCharacterNumber)
            {
                _selectionNames[i].SetActive(true);
            }
            else
            {
                _selectionNames[i].SetActive(false);
            }
        }
    }

    void JoinGame()
    {
        if (!_playerIsActive && Input.GetButtonDown(InputAxes.XBOX_A + _playerID))
        {
            _characterSelectPlayers._players.Add(this);
            _playerIsActive = true;
            _characterSelectPlayers.ActivePlayers++;
            _inputDelay = _inputDelayMaxTime;
        }
    }

    void LeaveGame()
    {
        //If player is active and ready , unready
        //If player is active but not ready , set inactive
        if (Input.GetButtonDown(InputAxes.XBOX_B + _playerID))
        {
            if (_playerIsActive && _ready)
            {
                _ready = false;
                _characterSelectPlayers.ReadyPlayers--;
            }
            else if (_playerIsActive && !_ready)
            {
                _playerIsActive = false;
                _characterSelectPlayers.ActivePlayers--;
                _characterSelectPlayers._players.Remove(this);
            }
        }
    }

    void NextCharacter()
    {
        //if dpad right go to next character
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) > 0 && _inputDelay <= 0)
        {
            if (_selectedCharacterNumber < _selectionPortraits.Count-1)
            {
                _selectedCharacterNumber++;
                Debug.Log(_selectedCharacterNumber);
            }
            else if (_selectedCharacterNumber  == _selectionPortraits.Count-1)
            {
                _selectedCharacterNumber = 0;
            }
            SelectedCharacterVisuals();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    void PreviousCharacter()
    {
        //if dpad left go to previous character
        if (Input.GetAxis(InputAxes.DPAD_X + _playerID) < 0 && _inputDelay <= 0)
        {
            if (_selectedCharacterNumber > 0)
            {
                _selectedCharacterNumber--;
            }
            else if (_selectedCharacterNumber == 0)
            {
                _selectedCharacterNumber = _selectionPortraits.Count-1;
            }
            SelectedCharacterVisuals();
            _inputDelay = _inputDelayMaxTime;
        }
    }

    void InputDelayTimer()
    {
        if (_inputDelay > 0)
        {
            _inputDelay -= Time.deltaTime;
        }
    }

    void SelectCharacter()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + _playerID) && _inputDelay <= 0)
        {
            PlayerParty.Players.Add(_characters[_selectedCharacterNumber]);
            PlayerCharacter playerCharacter = _characters[_selectedCharacterNumber].GetComponent<PlayerCharacter>();
            PlayerParty.PlayerCharacters.Add(playerCharacter);
            playerCharacter.PlayerID = _playerID; //Sets selected characters id equal to the players id who selected him
            _ready = true;
            _characterSelectPlayers.ReadyPlayers++;
            _inputDelay = _inputDelayMaxTime;
        }
    }

    void StartGame()
    {
        if (Input.GetButtonDown(InputAxes.START + _playerID))
        {
            SceneManager.LoadScene("Jordi");
        }
    }
}
