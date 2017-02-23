using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

    [SerializeField]private Transform _scoreboard;
    [SerializeField]private GameObject _scoreContainer;
    [SerializeField]private List<PlayerCharacter> _players = new List<PlayerCharacter>(); 

    void Start () {
        GetPlayers();
	}

	void Update () {
		
	}

    void GetPlayers()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag(Tags.PLAYER))
        {
            PlayerCharacter playerToAdd = player.GetComponent<PlayerCharacter>();
            _players.Add(playerToAdd);
        }
    }

    void CreateScoreboard()
    {
        foreach (PlayerCharacter player in _players)
        {
            GameObject scoreContainerObject = Instantiate(_scoreContainer);
            _scoreContainer.transform.SetParent(_scoreboard);
        }
    }

    void UpdateScore()
    {

    }

    void SortScore()
    {

    }
}
