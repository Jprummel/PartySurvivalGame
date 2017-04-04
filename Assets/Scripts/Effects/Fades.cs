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
        StartCoroutine(FadeIn(_fadeScreen));
	}

    public IEnumerator FadeOut(Image fadeImage, bool isLoadingScreen, float maxFadeTime)
    {
        Color fadeImageColor = fadeImage.color;
        float elapsedTime = 0.0f;
        fadeImage.gameObject.SetActive(true);

        if (isLoadingScreen)
        {
            _loadingObjects.SetActive(true);
        }
        while (elapsedTime <= 1.5f)
        {
            elapsedTime += Time.deltaTime;
            fadeImageColor.a = Mathf.Clamp01(elapsedTime / maxFadeTime);
            fadeImage.color = fadeImageColor;
            yield return null;
        }
    }

    public IEnumerator FadeIn(Image fadeImage)
    {
        Color fadeImageColor = fadeImage.color;
        fadeImage.gameObject.SetActive(true);
        float elapsedTime = 1.5f;
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            fadeImageColor.a = Mathf.Clamp01(elapsedTime / 1.5f);
            fadeImage.color = fadeImageColor;
            yield return null;
        }
    }
}
