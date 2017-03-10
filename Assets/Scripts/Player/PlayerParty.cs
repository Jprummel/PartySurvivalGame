using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    [SerializeField]private List<Transform> _spawnPoints = new List<Transform>();
    public static List<GameObject>      Players             = new List<GameObject>();
    public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();

	void Start () {
        AddPlayers();
	}

    void AddPlayers()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            GameObject Player = Instantiate(Players[i]);
            Player.transform.position = _spawnPoints[i].position;
        }
    }
}
