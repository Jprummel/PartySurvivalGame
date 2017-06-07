using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class SetVolumes : MonoBehaviour {

    [SerializeField]private AudioMixer _audioMixer;
    private SaveLoadSettings _saveLoadSettings;

    void Awake()
    {
        //_saveLoadSettings = GameObject.FindGameObjectWithTag(Tags.SAVELOADOBJECT).GetComponent<SaveLoadSettings>();
    }

	void Update () {
        SetVolume();
	}

    void SetVolume()
    {
        //Changes the volumes of all the audio groups in the audiomixer
        _audioMixer.SetFloat("Master", SettingsInformation.MasterVolume);
        _audioMixer.SetFloat("Music", SettingsInformation.MusicVolume);
        _audioMixer.SetFloat("SoundFX", SettingsInformation.SoundFXVolume);
    }

    //Call these functions from a sliders "On Value Change" function and assign that slider
    //to change the volumes

    public void ChangeMasterVolume(Slider volumeSlider)
    {
        SettingsInformation.MasterVolume = volumeSlider.value;
    }

    public void ChangeMusicVolume(Slider volumeSlider)
    {
        SettingsInformation.MusicVolume = volumeSlider.value;
    }

    public void ChangeSFXVolume(Slider volumeSlider)
    {
        SettingsInformation.SoundFXVolume = volumeSlider.value;
    }
}
