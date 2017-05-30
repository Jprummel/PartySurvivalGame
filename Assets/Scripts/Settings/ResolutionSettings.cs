using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour {

    [SerializeField]private Dropdown _resolutionDropdown;
    [SerializeField]private Toggle _fullScreenToggle;
    private SaveLoadSettings _saveSettings = new SaveLoadSettings();

    void Start()
    {

    }

    public void ChangeResolution()
    {
        switch(_resolutionDropdown.value){
            
            case 0:
                SettingsInformation.ResolutionWidth = 1024;
                SettingsInformation.ResoltuionHeight = 768;
                break;
            case 1:
                SettingsInformation.ResolutionWidth = 1280;
                SettingsInformation.ResoltuionHeight = 720;
                break;
            case 2:
                SettingsInformation.ResolutionWidth = 1366;
                SettingsInformation.ResoltuionHeight = 768;
                break;
            case 3:
                SettingsInformation.ResolutionWidth = 1600;
                SettingsInformation.ResoltuionHeight = 900;
                break;
            case 4:
                SettingsInformation.ResolutionWidth = 1920;
                SettingsInformation.ResoltuionHeight = 1080;
                break;
        }
        Screen.SetResolution(SettingsInformation.ResolutionWidth, SettingsInformation.ResoltuionHeight, SettingsInformation.IsFullScreen);
        _saveSettings.SaveSettings();
    }

    public void ToggleFullScreen()
    {

        if (_fullScreenToggle.isOn)
        {
            SettingsInformation.IsFullScreen = true;
        }
        else
        {
            SettingsInformation.IsFullScreen = false;
        }
        Screen.SetResolution(SettingsInformation.ResolutionWidth, SettingsInformation.ResoltuionHeight, SettingsInformation.IsFullScreen);
        _saveSettings.SaveSettings();
    }
}
