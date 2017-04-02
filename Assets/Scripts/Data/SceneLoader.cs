using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    [SerializeField]private float _waitingTime;
    private Fades _fades;
    private AsyncOperation _async = null;

    void Awake()
    {
        _fades = GameObject.FindGameObjectWithTag(Tags.FADEROBJECT).GetComponent<Fades>();
    }


    public void ChangeScene(string sceneName)
    {
        _async = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(_fades.FadeOut(true,1.5f));
        //_fades.FadeOut(false);
    }
}
