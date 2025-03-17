using System;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int populationStart = 5;
    [SerializeField] private int woodStart = 100;
    [SerializeField] private int meatStart = 100;
    [SerializeField] private int stoneStart = 100;
    [SerializeField] private int goldStart = 0;

    public TextMeshProUGUI populationText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI meatText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI goldText;

    public int currentStone;
    public int currentGold;
    public int currentPopulation;
    public int currentWood;
    public int currentMeat;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentPopulation = populationStart;
        currentWood = woodStart;
        currentMeat = meatStart;
        currentStone = stoneStart;
        currentGold = goldStart;

        UpdateUI();
    }

    private void UpdateUI()
    {
        populationText.text = currentPopulation.ToString();
        woodText.text = currentWood.ToString();
        meatText.text = currentMeat.ToString();
        stoneText.text = currentStone.ToString();
        goldText.text = currentGold.ToString();
    }

    public void SpendStoneForTowerLv1(int amount)
    {
        if (currentStone >= amount)
        {
            currentStone -= amount;
            UpdateUI();
            Debug.Log("Xây! Số đá còn lại: " + currentStone);
        }
        else
        {
            Debug.Log("Không đủ đá để xây!");
        }
    }
}
