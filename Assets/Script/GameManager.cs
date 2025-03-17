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

    public int stone;
    public int gold;
    public int population;
    public int wood;
    public int meat;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        population = populationStart;
        wood = woodStart;
        meat = meatStart;
        stone = stoneStart;
        gold = goldStart;

        UpdateUI();
    }

    private void UpdateUI()
    {
        populationText.text = population.ToString();
        woodText.text = wood.ToString();
        meatText.text = meat.ToString();
        stoneText.text = stone.ToString();
        goldText.text = gold.ToString();
    }

    public void SpendStoneForTowerLv1(int amount)
    {
        if (stone >= amount)
        {
            stone -= amount;
            UpdateUI();
            Debug.Log("Xây! Số đá còn lại: " + stone);
        }
        else
        {
            Debug.Log("Không đủ đá để xây!");
        }
    }
}
