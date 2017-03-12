using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPlayers : MonoBehaviour {

    [SerializeField]private GameObject _startText;
    public List<CharacterSelect> _players = new List<CharacterSelect>();
    private int _activePlayers;
    private int _readyPlayers;
    private bool _readyToStart;

    public int ActivePlayers
    {
        get { return _activePlayers; }
        set { _activePlayers = value; }
    }

    public int ReadyPlayers
    {
        get { return _readyPlayers; }
        set { _readyPlayers = value; }
    }

    public bool ReadyToStart { get { return _readyToStart; }}
	
	void Update () {
        CheckForStart();
	}

    void CheckForStart()
    {
        if (_readyPlayers == _activePlayers && _activePlayers > 0)
        {
            //able to start game
            _readyToStart = true;
            _startText.SetActive(true);
        }
        else
        {
            _readyToStart = false;
            _startText.SetActive(false);
        }
    }
}
