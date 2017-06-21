using UnityEngine;
using UnityEngine.UI;

public class ShowSettingValues : MonoBehaviour {

    [SerializeField]private Toggle      _fullscreenToggle;
    [SerializeField]private Dropdown    _resolutionDropdown;
    [SerializeField]private Toggle      _skipCutscenesToggle;
    [SerializeField]private Slider      _masterVolumeSlider;
    [SerializeField]private Slider      _musicVolumeSlider;
    [SerializeField]private Slider      _soundFXVolumeSlider;
	
	void Awake () {
        _fullscreenToggle.isOn      = SettingsInformation.IsFullScreen;
        _resolutionDropdown.value   = SettingsInformation.SelectedResolutionOption;
        _skipCutscenesToggle.isOn   = SettingsInformation.SkipCutscenes;
        _masterVolumeSlider.value   = SettingsInformation.MasterVolume;
        _musicVolumeSlider.value    = SettingsInformation.MusicVolume;
        _soundFXVolumeSlider.value  = SettingsInformation.SoundFXVolume;
	}
}
