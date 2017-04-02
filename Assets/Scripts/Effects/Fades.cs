using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fades : MonoBehaviour {

    [SerializeField]private Image _fadeScreen;
    [SerializeField]private GameObject _loadingObjects;
    private Color _fadeScreenColor;

	void Awake () {
        _fadeScreenColor = _fadeScreen.color;
        StartCoroutine(FadeIn());
	}

    public IEnumerator LoadingScreenFadeOut()
    {
        float elapsedTime = 0.0f;
        _fadeScreen.gameObject.SetActive(true);
        _loadingObjects.SetActive(true);
        while (elapsedTime <= 1.5f)
        {
            elapsedTime += Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
            yield return null;
        }
    }

    public IEnumerator FadeOut(bool isLoadingScreen, float maxFadeTime)
    {
        float elapsedTime = 0.0f;
        _fadeScreen.gameObject.SetActive(true);

        if (isLoadingScreen)
        {
            _loadingObjects.SetActive(true);
        }
        while (elapsedTime <= 1.5f)
        {
            elapsedTime += Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / maxFadeTime);
            _fadeScreen.color = _fadeScreenColor;
            yield return null;
        }
    }

    public IEnumerator FadeTransition()
    {
        float elapsedTime = 0.0f;
        _fadeScreen.gameObject.SetActive(true);

        while (elapsedTime <= 1.5f)
        {
            elapsedTime += Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
        }
        yield return new WaitForSeconds(1.5f);
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
        }

    }

    public IEnumerator FadeIn()
    {
        _fadeScreen.gameObject.SetActive(true);
        float elapsedTime = 1.5f;
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
            yield return null;
        }
    }

    public IEnumerator FadeTransition(bool doneFading)
    {
        float elapsedTime = 0.0f;
        //bool fadeOut = true;
        while (!doneFading)
        {
            elapsedTime += Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
        }
        /*while (!fadeOut && elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            _fadeScreenColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            _fadeScreen.color = _fadeScreenColor;
        }*/
        yield return null;
    }
}
