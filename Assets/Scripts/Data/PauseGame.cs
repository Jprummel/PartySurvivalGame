using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseGame : MonoBehaviour {


    [SerializeField]private GameObject _pauseScreen;
    private bool _gameIsPaused;
    private SceneLoader _sceneLoader;

    void Awake()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
    }

    public bool GameIsPaused
    {
        get { return _gameIsPaused; }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            _pauseScreen.SetActive(true);
            _gameIsPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            _pauseScreen.SetActive(false);
            _gameIsPaused = false;
            Time.timeScale = 1;
        }
    }

    public void BackToMenu()
    {
        GameInformation.Wave = 1;
        Time.timeScale = 1;
        _sceneLoader.ChangeScene("MainMenu");
    }

    public void BackToCharacterSelect()
    {
        GameInformation.Wave = 1;
        Time.timeScale = 1;
        _sceneLoader.ChangeScene("CharacterSelection");
    }
}
