using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class DayAndNight : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textTimeinGame;
    [SerializeField] public float dayDuration = 50f;
    public Light2D light2D;

    public void Update()
    {
        DateTime realTime = DateTime.Now;
        float realSecondInDay = (realTime.Hour * 3600) + (realTime.Minute * 60) + realTime.Second;
        realSecondInDay = (realSecondInDay * dayDuration) % 86400;

        int gameHours = Mathf.FloorToInt(realSecondInDay / 3600);
        int gameMinutes = Mathf.FloorToInt((realSecondInDay % 3600) / 60);

        string timeFormatted = string.Format("{0:00}:{1:00}", gameHours, gameMinutes);
        textTimeinGame.text = timeFormatted;

        if (gameHours >= 23 || gameHours < 5)
        {
            light2D.intensity = 0.3f; 
        }
        else
        {
            light2D.intensity = 1.0f;
        }
    }
}

