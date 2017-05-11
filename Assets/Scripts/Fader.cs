using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour {
    
    [SerializeField]private Image _fadeImage;    

	void Awake () 
    {
        Fade(0,3,_fadeImage);
    }

    public void Fade(float alpha, float fadeDuration, Image imageToFade = null)
    {
        if (imageToFade != null)
        {
            imageToFade.DOFade(alpha, fadeDuration);
        }
        else
        {
            _fadeImage.DOFade(alpha, fadeDuration);
        }
    }
}
