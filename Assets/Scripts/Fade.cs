using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour {
    
    [SerializeField]private Image _fadeImage;

	void Start () {
        FadeIn();
    }

    public void FadeOut()
    {
        _fadeImage.DOFade(1,3);
    }

    public void FadeIn()
    {
        _fadeImage.DOFade(0,2);
    }
}
