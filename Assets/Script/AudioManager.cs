using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip UpgradeAudioSource;
    [SerializeField] private AudioSource DayAudioSource;
    [SerializeField] private AudioSource NightAudioSource;
    [SerializeField] private AudioSource NoonAudioSource;

    [SerializeField] Slider volumeSlider;

    private const string VolumeKey = "musicVolume";


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

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        volumeSlider.value = volume;
        AudioListener.volume = volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }
}
