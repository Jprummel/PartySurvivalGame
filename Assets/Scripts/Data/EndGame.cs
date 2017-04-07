using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    [SerializeField]private Ranking _ranking;
    [SerializeField]private GameObject _gameOverScreen;
    private SceneLoader _sceneLoader;

    void Awake()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
    }

    void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (PlayerParty.PlayerCharacters.Count <= 0)
        {
            _gameOverScreen.SetActive(true);
            _ranking.ShowFinalRankings();
        }
    }

    public void BackToMenu()
    {
        GameInformation.Wave = 1;
        _sceneLoader.ChangeScene("MainMenu");      
    }

    public void BackToCharacterSelect()
    {
        GameInformation.Wave = 1;
        _sceneLoader.ChangeScene("CharacterSelection");
    }
}
