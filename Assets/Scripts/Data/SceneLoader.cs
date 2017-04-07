using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    [SerializeField]private float _waitingTime;
    [SerializeField]private Image _fadeScreen;
    private Fades _fades;
    private AsyncOperation _async = null;
    private bool _isLoading;

    void Awake()
    {
        _fades = GameObject.FindGameObjectWithTag(Tags.FADEROBJECT).GetComponent<Fades>();
    }


    public void ChangeScene(string sceneName)
    {
        if (!_isLoading)
        {
            _async = SceneManager.LoadSceneAsync(sceneName);
            StartCoroutine(_fades.FadeOut(_fadeScreen, true, 1.5f));
            _isLoading = true;
        }
    }
}
