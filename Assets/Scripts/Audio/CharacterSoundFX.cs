using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour {

    private AudioSource _audio;
    [SerializeField]private AudioClip _hitSound;
    [SerializeField]private AudioClip _deathSound;
    [SerializeField]private AudioClip _walkSound;
    [SerializeField]private AudioClip _lightAttackSound;
    [SerializeField]private AudioClip _heavyAttackSound;
    [SerializeField]private AudioClip _abilityOneSound;
    [SerializeField]private AudioClip _abilityTwoSound;

	void Start () {
        _audio = GetComponent<AudioSource>();
	}

    public void PlayHitAudio()
    {
        _audio.PlayOneShot(_hitSound);
    }

    public void PlayDeathSound()
    {
        _audio.PlayOneShot(_deathSound);
    }

    public void PlayWalkAudio()
    {
        if (!_audio.isPlaying)
        {
            _audio.PlayOneShot(_walkSound);
        }
    }

    public void PlayLightAttackAudio()
    {
        _audio.PlayOneShot(_lightAttackSound);
    }

    public void PlayHeavyAttackAudio()
    {
        _audio.PlayOneShot(_heavyAttackSound);
    }


    public void StopWalkSound()
    {
        _audio.Stop();
    }
}
