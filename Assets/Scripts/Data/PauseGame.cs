using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    private GameObject _pauseScreen;
    private bool _gameIsPaused;
    public bool GameIsPaused
    {
        get { return _gameIsPaused; }
    }

	void Start () {
        _pauseScreen = GameObject.FindGameObjectWithTag(Tags.PAUSESCREEN);
        _pauseScreen.SetActive(false);
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
}
