using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField]private float _waitingTime;
    [SerializeField]private GameObject _fadeScreen;
    private AsyncOperation _async = null;

    void Update()
    {
        if(_async != null){
            _fadeScreen.SetActive(true);
        }
    }

    public void ChangeScene(string sceneName)
    {
        _async = SceneManager.LoadSceneAsync(sceneName);

        //StartCoroutine(ChangeSceneRoutine(sceneName));
    }

    IEnumerator ChangeSceneRoutine(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        yield return _async;
        
        //SceneManager.LoadScene(sceneName);

    }

    /*public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/
}
