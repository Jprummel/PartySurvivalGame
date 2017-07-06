using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(ChangeSceneRoutine(sceneName));
        }
    }

    IEnumerator ChangeSceneRoutine(string sceneName)
    {
        _fader.Fade(1, 1.4f);
        yield return new WaitForSeconds(1.5f);
        _async = SceneManager.LoadSceneAsync(sceneName);
        _isLoading = true;
    }
}
