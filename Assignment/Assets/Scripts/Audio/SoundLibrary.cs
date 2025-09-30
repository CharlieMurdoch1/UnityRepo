using UnityEngine;

[System.Serializable]
public struct Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundLibrary : MonoBehaviour
{
    public Sound[] sounds;

    //Loop through all tracks and return the clip with matching name
    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var sound in sounds)
        {
            if (sound.soundName == trackName)
            {
                return sound.clip;
            }
        }
        return null;
    }
}
