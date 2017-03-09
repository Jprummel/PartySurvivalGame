using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField]private float _waitingTime;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneRoutine(sceneName));
    }

    IEnumerator ChangeSceneRoutine(string sceneName)
    {
        yield return new WaitForSeconds(_waitingTime);
        SceneManager.LoadScene(sceneName);

    }
}
