using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    [SerializeField]private Text _finalRankingText;
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
        
    }

    void GetPlayers()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            _players.Add(PlayerParty.PlayerCharacters[i]);
        }
    }
}
