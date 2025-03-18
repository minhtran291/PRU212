using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textTimeinGame;
    [SerializeField] public TextMeshProUGUI textDayinGame;
    [SerializeField] public float dayDuration = 100f;
    [SerializeField] private AudioManager AudioManager;
    public Light2D light2D;

    private float gameTimeInSeconds;
    public int gameDay = 1;
    public bool isDay = false;

    private void Start()
    {
        gameTimeInSeconds = 5 * 3600;
        UpdateDayText();
    }

    private void Update()
    {
        gameTimeInSeconds += Time.deltaTime * (86400 / dayDuration); 

        if (gameTimeInSeconds >= 86400)
        {
            gameTimeInSeconds = 0;
            gameDay++;
            UpdateDayText();
        }

        int gameHours = Mathf.FloorToInt(gameTimeInSeconds / 3600);
        int gameMinutes = Mathf.FloorToInt((gameTimeInSeconds % 3600) / 60);

        string timeFormatted = string.Format("{0:00}:{1:00}", gameHours, gameMinutes);
        textTimeinGame.text = timeFormatted;

        if (gameHours >= 23 || gameHours < 5)
        {
            light2D.intensity = 0.3f;
            if (!isDay)
            {
                AudioManager.PlayDayAudioSource();
                isDay = true;
            }
        }
        else
        {
            light2D.intensity = 1.0f;
            if (isDay)
            {
                AudioManager.PlayNightAudioSource();
                isDay = false;
            }
        }
    }

    private void UpdateDayText()
    {
        textDayinGame.text = "Day " + gameDay;
    }
}
