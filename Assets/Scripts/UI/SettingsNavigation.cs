using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsNavigation : MonoBehaviour {

    [SerializeField]private GameObject _mainMenu;
    [SerializeField]private GameObject _displaySettingsPanel;
    [SerializeField]private GameObject _audioSettingsPanel;

    public void OpenSettings()
    {
        _mainMenu.SetActive(false);
        _displaySettingsPanel.SetActive(true);
    }

    public void ShowDisplaySettings()
    {
        _mainMenu.SetActive(false);        
        _audioSettingsPanel.SetActive(false);
        _displaySettingsPanel.SetActive(true);
    }

    public void ShowAudioSettings()
    {
        _mainMenu.SetActive(false);
        _displaySettingsPanel.SetActive(false);
        _audioSettingsPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        _audioSettingsPanel.SetActive(false);
        _displaySettingsPanel.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
