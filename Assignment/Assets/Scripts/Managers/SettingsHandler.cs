using UnityEngine;

public static class SettingsHandler
{
    public static float MouseSensitivity = 200f;
    public static float TargetFPS = 60f;
    public static float MasterVol = 0f;
    public static float SfxVol = 0f;
    public static float MusicVol = 0f;

    //Save current values to player prefs
    public static void SavePrefs()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", MouseSensitivity);
        PlayerPrefs.SetFloat("MasterVol", MasterVol);
        PlayerPrefs.SetFloat("SfxVol", SfxVol);
        PlayerPrefs.SetFloat("MusicVol", MusicVol);
    }

    //Load values from player prefs;
    public static void LoadPrefs()
    {
        MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 200f);
        MasterVol = PlayerPrefs.GetFloat("MasterVol", 0f);
        SfxVol = PlayerPrefs.GetFloat("SfxVol", 0f);
        MusicVol = PlayerPrefs.GetFloat("MusicVol", 0f);
    }
}