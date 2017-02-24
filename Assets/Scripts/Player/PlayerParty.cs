using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    [SerializeField]private List<GameObject> _players = new List<GameObject>();
    [SerializeField]private List<PlayerCharacter> _playerCharacters = new List<PlayerCharacter>();
	// Use this for initialization
	void Start () {
        AddPlayers();
        AddCharacters();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void AddPlayers()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag(Tags.PLAYER))
        {
            _players.Add(player);
        }
    }

    void AddCharacters()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            PlayerCharacter characterToAdd = _players[i].GetComponent<PlayerCharacter>();
            _playerCharacters.Add(characterToAdd);
        }
    }
}
