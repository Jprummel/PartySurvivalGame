using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour {

    [SerializeField]private Dropdown _resolutionDropdown;
    [SerializeField]private Toggle _fullScreenToggle;
    private SaveLoadSettings _saveSettings = new SaveLoadSettings();

    public void ChangeResolution()
    {
        switch(_resolutionDropdown.value){
            
            case 0:
                SettingsInformation.ResolutionWidth = 1024;
                SettingsInformation.ResolutionHeight = 768;
                SettingsInformation.SelectedResolutionOption = 0;
                break;
            case 1:
                SettingsInformation.ResolutionWidth = 1280;
                SettingsInformation.ResolutionHeight = 720;
                SettingsInformation.SelectedResolutionOption = 1;
                break;
            case 2:
                SettingsInformation.ResolutionWidth = 1366;
                SettingsInformation.ResolutionHeight = 768;
                SettingsInformation.SelectedResolutionOption = 2;
                break;
            case 3:
                SettingsInformation.ResolutionWidth = 1600;
                SettingsInformation.ResolutionHeight = 900;
                SettingsInformation.SelectedResolutionOption = 3;
                break;
            case 4:
                SettingsInformation.ResolutionWidth = 1920;
                SettingsInformation.ResolutionHeight = 1080;
                SettingsInformation.SelectedResolutionOption = 4;
                break;
        }
        Screen.SetResolution(SettingsInformation.ResolutionWidth, SettingsInformation.ResolutionHeight, SettingsInformation.IsFullScreen);
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
        Screen.SetResolution(SettingsInformation.ResolutionWidth, SettingsInformation.ResolutionHeight, SettingsInformation.IsFullScreen);
        _saveSettings.SaveSettings();
    }
}
