using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    public Button soundButton;
    public Button playButton;
    public Button quitButton;

    public AudioSource backgroundMusic;
    private bool isSoundOn = true;

    void Start()
    {
        soundButton.onClick.AddListener(ToggleSound);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        UpdateSoundButton();
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        backgroundMusic.mute = !isSoundOn;

        UpdateSoundButton();
    }

    void UpdateSoundButton()
    {
        if (isSoundOn)
        {
            soundButton.GetComponentInChildren<Text>().text = "Âm thanh: Bật";
            soundButton.image.color = Color.white;
        }
        else
        {
            soundButton.GetComponentInChildren<Text>().text = "Âm thanh: Tắt";
            soundButton.image.color = Color.gray;
        }
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Maps");
    }

    void OnQuitButtonClicked()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
