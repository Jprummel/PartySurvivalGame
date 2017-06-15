using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    //Script imports
    [SerializeField]private SelectionScreen _selectionScreen;
    private CharacterSelectPlayers          _characterSelectPlayers;
    private CharacterSelectUI               _characterSelectUI;
    private CharacterSelectInput            _input;
    
    //UI
    [SerializeField]private GameObject _readyText;

    private bool _characterSelectState;
    private bool _playerIsActive;
    private bool _ready;

    public bool PlayerIsActive
    {
        get { return _playerIsActive; }
        set { _playerIsActive = value; }
    }

    public bool PlayerIsReady
    {
        get { return _ready; }
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
        _characterSelectPlayers = GameObject.FindGameObjectWithTag(Tags.CHARACTERSELECTOBJECT).GetComponent<CharacterSelectPlayers>();
        _characterSelectUI      = GetComponent<CharacterSelectUI>();
        _input                  = GetComponent<CharacterSelectInput>();
    }

    public void JoinGame()
    {
        if (!_playerIsActive)
        {
            _characterSelectPlayers._players.Add(this);
            _playerIsActive = true;
            _characterSelectPlayers.ActivePlayers++;
        }
    }

    public void LeaveGame()
    {
        if (_playerIsActive && !_ready) //If player is active but not ready , set inactive
        {
            _playerIsActive = false; //Sets player inactive
            _characterSelectPlayers.ActivePlayers--;        //Reduces the active players
            _characterSelectPlayers._players.Remove(this);  //Removes this player from the character selection player list
        }
        if (_characterSelectPlayers.ActivePlayers <= 0)
        {
            StartCoroutine(_selectionScreen.SwitchToMapSelect());
        }
    }

    public void UnReady()
    {
        if (_playerIsActive && _ready) //If player is active and ready , unready
        {
            _readyText.SetActive(false);
            _ready = false;
            _characterSelectPlayers.ReadyPlayers--;
        }
    }
    
    public void ReadyUp()
    {
        //Sets the players state to ready in the character selection screen
        _ready = true;
        _readyText.SetActive(true);
        _characterSelectPlayers.ReadyPlayers++;
    }
}