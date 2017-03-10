using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    private GameObject _pauseScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
