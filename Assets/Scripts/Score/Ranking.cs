using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    [SerializeField]private List<GameObject> _rankingObjects = new List<GameObject>();
    [SerializeField]private List<Image> _playerPortraits = new List<Image>();
    private List<PlayerCharacter> _players = new List<PlayerCharacter>();

	void Start () {
        GetPlayers();
	}

    public void UpdateRanks()
    {
        _players.Sort((player1,player2) => player2.TotalGoldEarned.CompareTo(player1.TotalGoldEarned));
        for (int i = 0; i < _players.Count; i++)
        {
            switch (i)
            {
                case 0:
                    _players[i].HUD.RankText.text = "1st";
                    break;
                case 1:
                    _players[i].HUD.RankText.text = "2nd";
                    break;
                case 2:
                    _players[i].HUD.RankText.text = "3rd";
                    break;
                case 4:
                    _players[i].HUD.RankText.text = "4th";
                    break;
            }
        }
    }

    public void ShowFinalRankings()
    {
        for (int i = 0; i < _players.Count; i++) //this loop disables the portraits and texts for ranks that shouldnt be there
        {
            if (_players[i] != null)
            {
                _rankingObjects[i].SetActive(true);
            }
        }

        for (int i = 0; i < _players.Count; i++)
        {
            _playerPortraits[i].sprite = _players[i].Portrait;
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
