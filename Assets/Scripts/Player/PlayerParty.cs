using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    public static List<GameObject>      Players             = new List<GameObject>();
    public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();

	void Start () {
        AddPlayers();
        //AddCharacters();
	}

    void AddPlayers()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            GameObject Player = Instantiate(Players[i]);
        }
    }

    /*void AddCharacters()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            PlayerCharacter characterToAdd = Players[i].GetComponent<PlayerCharacter>();
            PlayerCharacters.Add(characterToAdd);                       
        }
    }*/
}
