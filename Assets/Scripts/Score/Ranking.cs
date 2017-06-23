using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    [SerializeField]private List<GameObject> _rankingObjects = new List<GameObject>();
    [SerializeField]private List<Image> _playerPortraits = new List<Image>();
    [SerializeField]private List<Text> _goldEarned = new List<Text>();
    private List<PlayerCharacter> _players = new List<PlayerCharacter>();

	void Start () {
        GetPlayers();
	}

    public void UpdateRanks()
    {
        _players.Sort((player1,player2) => player2.TotalGoldEarned.CompareTo(player1.TotalGoldEarned));
    }

    public void ShowFinalRankings()
    {
        for (int i = 0; i < _players.Count; i++) //this loop disables the portraits and texts for ranks that shouldnt be there
        {
            if (_players[i] != null)
            {
                _rankingObjects[i].SetActive(true);
            }
            else
            {
                _rankingObjects[i].SetActive(false);
            }
        }

        for (int i = 0; i < _players.Count; i++)
        {
            _playerPortraits[i].sprite = _players[i].GameOverPortrait;
            _goldEarned[i].text = "Earned" + "\n" + _players[i].TotalGoldEarned;            
        }
    }

    void GetPlayers()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            _players.Add(PlayerParty.PlayerCharacters[i]);
        }
    }
}
