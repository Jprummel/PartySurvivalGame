using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerParty : MonoBehaviour {

    [SerializeField]private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField]private List<Transform> _deadPlayerSpawnPoints = new List<Transform>();
    public static List<GameObject>      Players             = new List<GameObject>();
    public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();
    private List<GameObject> _ingamePlayers = new List<GameObject>();

    public List<GameObject> InGamePlayers
    {
        get { return _ingamePlayers; }
    }

	void Awake () {
        SortPlayerLists();
        AddPlayers();   
	}

    void Update()
    {
        if(WaveController.newWave != null)
        {
            SetPosition();
        }
    }

    void AddPlayers()
    {
        //Spawns the players
        for (int i = 0; i < Players.Count; i++)
        {
            GameObject Player = Instantiate(Players[i]);
            Player.transform.position = _spawnPoints[i].position;
            _ingamePlayers.Add(Player);
        }
    }

    void SetPosition()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            if (_ingamePlayers[i].gameObject.tag == Tags.PLAYER)
            {
                _ingamePlayers[i].transform.position = _spawnPoints[i].position;
            }
            else
            {
                _ingamePlayers[i].transform.position = _deadPlayerSpawnPoints[i].position;
            }
        }
    }

    void SortPlayerLists()
    {
        //Sorts the Player and PlayerCharacters list by playerID (so player 1 is always the first in the list and player 4 always the last)
        Players.Sort((player1, player2) => player1.GetComponent<PlayerCharacter>().PlayerID.CompareTo(player2.GetComponent<PlayerCharacter>().PlayerID));
        PlayerCharacters.Sort((x,y) => x.PlayerID.CompareTo(y.PlayerID));
    }
}
