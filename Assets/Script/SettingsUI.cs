using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SettingsUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button closeButton, backButton, saveButton;
    public Button openPanelButton;

    private void Start()
    {
        openPanelButton.onClick.AddListener(OpenPanel);
        closeButton.onClick.AddListener(ClosePanel);
        backButton.onClick.AddListener(BackToMainMenu);
        saveButton.onClick.AddListener(SaveGame);
    }

    private void OpenPanel()
    {
        settingsPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        settingsPanel.SetActive(false);
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveGame(){

    }


    public void TogglePanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

}
