using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour {

    private AudioSource _audio;
    [SerializeField]private List<AudioClip> _hitSounds = new List<AudioClip>();
    [SerializeField]private AudioClip _deathSound;
    [SerializeField]private AudioClip _walkSound;
    [SerializeField]private AudioClip _lightAttackSound;
    [SerializeField]private AudioClip _heavyAttackSound;
    [SerializeField]private AudioClip _abilitySound;

	void Start () {
        _audio = GetComponent<AudioSource>();
	}

    public void PlayHitAudio()
    {
        int playSoundChance = Random.Range(0, 100);
        if (playSoundChance <= 33)
        {
            int randomHitSound = Random.Range(0, _hitSounds.Count);
            _audio.PlayOneShot(_hitSounds[randomHitSound]);
        }
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

    public void PlayAbilitySound()
    {
        _audio.PlayOneShot(_abilitySound);
    }

    public void StopWalkSound()
    {
        _audio.Stop();
    }
}
