using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    [SerializeField]public static List<GameObject>      Players             = new List<GameObject>();
    [SerializeField]public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();

	// Use this for initialization
	void Start () {
        AddPlayers();
        AddCharacters();
	}

    void AddPlayers()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag(Tags.PLAYER))
        {
            Players.Add(player);
        }
    }

    void AddCharacters()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            PlayerCharacter characterToAdd = Players[i].GetComponent<PlayerCharacter>();
            PlayerCharacters.Add(characterToAdd);                       
        }
    }
}
