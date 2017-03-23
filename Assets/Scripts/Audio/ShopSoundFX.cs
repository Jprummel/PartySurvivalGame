using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSoundFX : MonoBehaviour {

    private AudioSource _audio;
    [SerializeField]private List<AudioClip> _buySounds = new List<AudioClip>();
    [SerializeField]private AudioClip _warhorn;

	void Start () {
        _audio = GetComponent<AudioSource>();
	}

    public void PlayBuySound()
    {
        int randomBuySound = Random.Range(0, _buySounds.Count);
        _audio.PlayOneShot(_buySounds[randomBuySound]);
    }

    public void PlayWarhorn()
    {
        _audio.PlayOneShot(_warhorn);
    }
}
