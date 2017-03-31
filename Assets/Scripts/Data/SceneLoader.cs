using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    [SerializeField]private float _waitingTime;
    [SerializeField]private Image _fadeScreen;
    private AsyncOperation _async = null;
    private Color _fadeScreenColor;

    void Awake()
    {
        _fadeScreenColor = _fadeScreen.color;
        StartCoroutine(FadeIn());
    }


    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneRoutine(sceneName));
    }

    IEnumerator ChangeSceneRoutine(string sceneName)
    {
        float elapsedTime = 0.0f;
        _fadeScreen.gameObject.SetActive(true);
        _async = SceneManager.LoadSceneAsync(sceneName);
        while (!_async.isDone)
        {            
            elapsedTime += Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime/ 1.5f);
            _fadeScreen.color = _fadeScreenColor;
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 1.5f;
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
            yield return null;
        }
    }
}
