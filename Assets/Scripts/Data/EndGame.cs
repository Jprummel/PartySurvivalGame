using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    [SerializeField]private Ranking _ranking;
    [SerializeField]private GameObject _gameOverScreen;


	void Update () {
        //Keeps checking if all players are dead, if so then show the gameover screen
        if (PlayerParty.PlayerCharacters.Count <= 0)
        {
            GameOver();
        }
	}

    void GameOver()
    {
        _gameOverScreen.SetActive(true);
        _ranking.ShowFinalRankings();
    }

    public void BackToMenu()
    {
        PlayerParty.Players.Clear(); //Clears the players list so there wont be duplicate characters the next round
        GameInformation.Wave = 1;
        SceneLoader.LoadScene("MainMenu");        
    }

    public void BackToCharacterSelect()
    {
        PlayerParty.Players.Clear();//Clears the players list so there wont be duplicate characters the next round
        GameInformation.Wave = 1;
        SceneLoader.LoadScene("CharacterSelection");
    }
}
