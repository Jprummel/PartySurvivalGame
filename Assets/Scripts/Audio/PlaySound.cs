using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    
    [SerializeField]private List<AudioClip> _soundEffects = new List<AudioClip>();
    private AudioSource _audio;

	void Start () {
        _audio = GetComponent<AudioSource>();
	}

    public void PlaySFX(int sfxNumber)
    {
        _audio.PlayOneShot(_soundEffects[sfxNumber]);
    }
}
