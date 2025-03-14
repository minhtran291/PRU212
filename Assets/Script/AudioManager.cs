using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip UpgradeAudioSource;
    [SerializeField] private AudioSource DayAudioSource;
    [SerializeField] private AudioSource NightAudioSource;
    [SerializeField] private AudioSource NoonAudioSource;

    public void PlayUpgradeSound()
    {
        effectAudioSource.PlayOneShot(UpgradeAudioSource);
    }

    public void PlayDayAudioSource()
    {
        DayAudioSource.Play();
        NightAudioSource.Stop();
        NoonAudioSource.Stop();
    }
    public void PlayNoonAudioSource()
    {
        DayAudioSource.Stop();
        NightAudioSource.Stop();
        NoonAudioSource.Play();
    }
    public void PlayNightAudioSource()
    {
        DayAudioSource.Stop();
        NightAudioSource.Play();
        NoonAudioSource.Stop();
    }
}
