using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class SetVolumes : MonoBehaviour {

    //Fill the list in the editor
    [SerializeField]private AudioMixer _audioMixer;
    [SerializeField]private List<AudioSource> _musicSources         = new List<AudioSource>();
    [SerializeField]private List<AudioSource> _soundEffectSources   = new List<AudioSource>();
    private float _musicVolume;
    private float _sfxVolume;
	
	void Update () {
        SetVolume();
	}

    void SetVolume()
    {
        //Changes the volume for all music sources and SFX sources to the values in AudioData
        foreach (AudioSource source in _musicSources)
        {
            if (source != null)
            {
                source.volume = SettingsInformation.MusicVolume;
            }
        }

        foreach (AudioSource source in _soundEffectSources)
        {
            if (source != null)
            {
                source.volume = SettingsInformation.SoundFXVolume;
            }
        }
    }

    //Call these functions from a sliders "On Value Change" function and assign that slider
    //to change the volumes
    public void ChangeMusicVolume(Slider volumeSlider)
    {
        //_audioMixer.SetFloat("Music", volumeSlider);
        SettingsInformation.MusicVolume = volumeSlider.value;
    }

    public void ChangeSFXVolume(Slider volumeSlider)
    {
        //_audioMixer.SetFloat("SoundFX", volumeSlider);
        SettingsInformation.SoundFXVolume = volumeSlider.value;
    }
}
