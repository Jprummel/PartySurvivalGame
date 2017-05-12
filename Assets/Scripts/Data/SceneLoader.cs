using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private Fader _fader;
    private AsyncOperation _async = null;
    private bool _isLoading;

    void Awake()
    {
        _fader = GameObject.FindGameObjectWithTag(Tags.FADEPANEL).GetComponent<Fader>();
    }

    public void ChangeScene(string sceneName)
    {
        if (!_isLoading)
        {
            _async = SceneManager.LoadSceneAsync(sceneName);
            _fader.Fade(1,3);
            _isLoading = true;
        }
    }
}
