using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer AudioMixer;


    [SerializeField] private AudioSource soundSource;
    [SerializeField] private SoundLibrary soundLibrary;
    

    private void Awake()
    {
        //Check if this is the only Audio manager
        if (Instance != null)
        {
            Debug.LogError("Warning: More than one Audio Manager detected on load");
            Destroy(this.gameObject);
            return;
        }

        //Setup this as the persisting Audio manager
        Instance = this;
        DontDestroyOnLoad(this);
    }

    //Play sound clip based on name string which matches to a named clip in the SoundLibrary
    public void PlaySound(string name)
    {
        AudioClip clip = soundLibrary.GetClipFromName(name);

        if (clip != null)
        {
            soundSource.clip = clip;
            soundSource.Play();
        }
    }

    //Loads the values stored in the SettingsHandler and applies them to the AudioMixer group.
    public void UpdateMixerLevels()
    {
        AudioMixer.SetFloat("MasterVolume", SettingsHandler.MasterVol);
        AudioMixer.SetFloat("SfxVolume", SettingsHandler.SfxVol);
        AudioMixer.SetFloat("MusicVolume", SettingsHandler.MusicVol);
    }
}
