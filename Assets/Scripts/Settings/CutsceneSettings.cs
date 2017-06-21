using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneSettings : MonoBehaviour {

    [SerializeField] private Toggle _cutscenesToggle;
    private SaveLoadSettings _saveSettings = new SaveLoadSettings();

    public void ToggleSkipCutscenes()
    {
        if (_cutscenesToggle.isOn)
        {
            SettingsInformation.SkipCutscenes = true;
        }
        else
        {
            SettingsInformation.SkipCutscenes = false;
        }
        _saveSettings.SaveSettings();
    }
}
