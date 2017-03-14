using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerParty : MonoBehaviour {

    [SerializeField]private List<Transform> _spawnPoints = new List<Transform>();
    public static List<GameObject>      Players             = new List<GameObject>();
    public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();

	void Awake () {
        SortPlayerLists();
        AddPlayers();   
	}

    void AddPlayers()
    {
        //Spawns the players
        for (int i = 0; i < Players.Count; i++)
        {
            GameObject Player = Instantiate(Players[i]);
            Player.transform.position = _spawnPoints[i].position;
        }
    }

    void SortPlayerLists()
    {
        //Sorts the Player and PlayerCharacters list by playerID (so player 1 is always the first in the list and player 4 always the last)
        Players.Sort((player1, player2) => player1.GetComponent<PlayerCharacter>().PlayerID.CompareTo(player2.GetComponent<PlayerCharacter>().PlayerID));
        PlayerCharacters.Sort((x,y) => x.PlayerID.CompareTo(y.PlayerID));
    }
}
