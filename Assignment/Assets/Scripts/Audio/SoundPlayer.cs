using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private string soundName;
    public void PlaySound()
    {
        AudioManager.Instance.PlaySound(soundName);
    }
}
