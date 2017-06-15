using UnityEngine;

[System.Serializable]
public class SettingsInformation : MonoBehaviour {

    //Resolution Settings
    public static int ResolutionWidth;
    public static int ResoltuionHeight;
    public static bool IsFullScreen;

    //Audio Settings
    public static float MasterVolume;
    public static float SoundFXVolume;
    public static float MusicVolume;

    //Cutscene settings
    public static bool SkipCutscenes;
}
