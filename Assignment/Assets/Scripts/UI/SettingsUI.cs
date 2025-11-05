using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;

    private void Start()
    {
        //Load saved values from the SettingsHandler and set slider values.
        SettingsHandler.LoadPrefs();
        MasterSlider.value = SettingsHandler.MasterVol;
        MusicSlider.value = SettingsHandler.MusicVol;
        SfxSlider.value = SettingsHandler.SfxVol;
    }

   
    public void ChangeMasterVol() //Called on slider change. Sets value in Settings handler and then updates the AudioMixer group.
    {
        SettingsHandler.MasterVol = MasterSlider.value;
        AudioManager.Instance.UpdateMixerLevels();
        AudioManager.Instance.PlaySound("click");
    }

    
    public void ChangeSfxVol() //Called on slider change. Sets value in Settings handler and then updates the AudioMixer group.
    {
        SettingsHandler.SfxVol = SfxSlider.value;
        AudioManager.Instance.UpdateMixerLevels();
        AudioManager.Instance.PlaySound("click");
    }

    
    public void ChangeMusicVol() //Called on slider change. Sets value in Settings handler and then updates the AudioMixer group.
    {
        SettingsHandler.MusicVol = MusicSlider.value;
        AudioManager.Instance.UpdateMixerLevels();
        AudioManager.Instance.PlaySound("click");
    }

    
    public void ApplySettingsChanges() //Called when player exits the menu
    {
        AudioManager.Instance.PlaySound("click");
        SettingsHandler.SavePrefs();
    }
}
