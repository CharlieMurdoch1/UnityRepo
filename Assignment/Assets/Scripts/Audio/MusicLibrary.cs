using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string trackName;
    public AudioClip clip;
}

public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks;

    //Loop through all tracks and return the clip with matching name
    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks) 
        { 
            if(track.trackName == trackName)
            {
                return track.clip;
            }
        }
        return null; 
    }
}
