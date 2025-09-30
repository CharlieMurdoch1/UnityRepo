using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private MusicLibrary musicLibrary;
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        //Check if this is the only music manager
        if (Instance != null)
        {
            Debug.LogError("Warning: More than one Music Manager detected on load");
            Destroy(this.gameObject);
            return;
        }

        //Setup this as the persisting music manager
        Instance = this;
        DontDestroyOnLoad(this);

        //Start playing music
        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        // Get the next track in the list (loop back to the first track if at the end)
        if (musicLibrary.tracks.Length == 0) return;

        // Loop to next track
        MusicTrack newTrack = musicLibrary.tracks[Random.Range(0, musicLibrary.tracks.Length)];

        AudioClip nextTrack = newTrack.clip;
        musicSource.clip = nextTrack;
        Debug.Log("Playing new track: " + newTrack.trackName);
        musicSource.Play();

        // Wait for the current track to finish and play the next one
        StartCoroutine(WaitForTrackEnd());
    }

    private IEnumerator WaitForTrackEnd()
    {
        // Wait for the current track to finish
        while (musicSource.isPlaying)
        {
            yield return null;
        }

        // Once finished, play the next track
        PlayNextTrack();
    }
}
