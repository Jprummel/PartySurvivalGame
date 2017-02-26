using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void ChangeScene(string sceneName, float waitingTime)
    {
        StartCoroutine(ChangeSceneRoutine(sceneName,waitingTime));
    }

    IEnumerator ChangeSceneRoutine(string sceneName, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);

    }
}
