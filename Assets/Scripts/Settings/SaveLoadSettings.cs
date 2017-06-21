using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSettings : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadSettings();
    }

    public void SaveSettings()
    {
        //Save the settings
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavedSettingsSlot.dat");

        SettingsData settingsData               = new SettingsData();
        settingsData.ResolutionWidth            = SettingsInformation.ResolutionWidth;
        settingsData.ResolutionHeight           = SettingsInformation.ResolutionHeight;
        settingsData.SelectedResolutionOption   = SettingsInformation.SelectedResolutionOption;
        settingsData.IsFullScreen               = SettingsInformation.IsFullScreen;
        settingsData.MasterVolume               = SettingsInformation.MasterVolume;
        settingsData.SoundFXVolume              = SettingsInformation.SoundFXVolume;
        settingsData.MusicVolume                = SettingsInformation.MusicVolume;
        settingsData.SkipCutscenes              = SettingsInformation.SkipCutscenes;
        bf.Serialize(file, settingsData);
        file.Close();
    }

    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedSettingsSlot.dat"))
        {
            //If there is a save file of the settings, load the settings
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedSettingsSlot.dat", FileMode.Open);

            SettingsData settingsData                       = (SettingsData)bf.Deserialize(file);

            SettingsInformation.ResolutionWidth             = settingsData.ResolutionWidth;
            SettingsInformation.ResolutionHeight            = settingsData.ResolutionHeight;
            SettingsInformation.SelectedResolutionOption    = settingsData.SelectedResolutionOption;
            SettingsInformation.IsFullScreen                = settingsData.IsFullScreen;
            SettingsInformation.MasterVolume                = settingsData.MasterVolume;
            SettingsInformation.SoundFXVolume               = settingsData.SoundFXVolume;
            SettingsInformation.MusicVolume                 = settingsData.MusicVolume;
            SettingsInformation.SkipCutscenes               = settingsData.SkipCutscenes;
            file.Close();
        }
        else
        {
            ResetToDefaultSettings();
        }
    }

    public void ResetToDefaultSettings()
    {
        //If there is no save file of the settings or player wants to reset them set these as the default
        Debug.Log("Loaded Defaults");
        SettingsInformation.ResolutionWidth             = 1920;
        SettingsInformation.ResolutionHeight            = 1080;
        SettingsInformation.SelectedResolutionOption    = 4;
        SettingsInformation.IsFullScreen                = true;
        SettingsInformation.MasterVolume                = 1;
        SettingsInformation.SoundFXVolume               = 1;
        SettingsInformation.MusicVolume                 = 1;
        SettingsInformation.SkipCutscenes               = false;
    }
}
[System.Serializable]
public class SettingsData
{
    //Graphic Settings
    public int ResolutionWidth;
    public int ResolutionHeight;
    public int SelectedResolutionOption;
    public bool IsFullScreen;

    //Audio Settings
    public float MasterVolume;
    public float SoundFXVolume;
    public float MusicVolume;

    //Cutscene Settings
    public bool SkipCutscenes;
}