using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundFX : MonoBehaviour {

    private AudioSource _audio;
    [SerializeField]private AudioClip _warhorn;

	void Start () {
		_audio = GetComponent<AudioSource>();
	}
	
    public void PlayStartWaveSound()
    {
        _audio.PlayOneShot(_warhorn);
    }
}
