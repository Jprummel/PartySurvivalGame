using UnityEngine;
using UnityEngine.UI;

public class ShowSettingValues : MonoBehaviour {

    [SerializeField]private Toggle _fullscreenToggle;
    [SerializeField]private Dropdown _resolutionDropdown;
    [SerializeField]private Slider _masterVolumeSlider;
    [SerializeField]private Slider _musicVolumeSlider;
    [SerializeField]private Slider _soundFXVolumeSlider;
	
	void Start () {
        //_fullscreenToggle
        _masterVolumeSlider.value   = SettingsInformation.MasterVolume;
        _musicVolumeSlider.value    = SettingsInformation.MusicVolume;
        _soundFXVolumeSlider.value  = SettingsInformation.SoundFXVolume;
	}
}
