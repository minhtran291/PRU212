using System;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int populationStart = 5;
    [SerializeField] private int woodStart = 1000;
    [SerializeField] private int meatStart = 1000;
    [SerializeField] private int stoneStart = 1000;
    [SerializeField] private int goldStart = 1000;
    [SerializeField] private int level = 1;
    [SerializeField] private int dayInGame = 1;
    public int numberOfTowerMaxInLevel = 2;
    public int numberOfFarmerHouseMaxInLevel = 1;
    public int numberOfWoodHouseMaxInLevel = 1;
    public int numberOfOreStoneHouseMaxInLevel = 1;
    public int numberOfOreGoldHouseMaxInLevel = 1;
    public int numberOfBarracksMaxInLevel = 1;

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

    public int currentOreStone;
    public int currentOreGold;
    public int currentBarracks;
    public int currentTower;
    public int currentFarmerHouse;
    public int currentWoodHouse;
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
        numberOfTowerMaxInLevel *= level;
        numberOfFarmerHouseMaxInLevel *= level;
        numberOfWoodHouseMaxInLevel *= level;
        numberOfOreStoneHouseMaxInLevel *= level;
        numberOfOreGoldHouseMaxInLevel *= level;
        numberOfBarracksMaxInLevel *= level;
        UpdateUI();
    }

    public void UpdateUI()
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
