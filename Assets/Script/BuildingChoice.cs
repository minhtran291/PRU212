using Assets.Entity;
using Assets.Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingChoice : MonoBehaviour
{
    [SerializeField] GameObject buildingChoice;
    [SerializeField] private Sprite[] buildingSprites;
    [SerializeField] private Button[] buildingButton;
    [SerializeField] private CostBuilding costBaseFarmerBuilding;
    [SerializeField] private CostBuilding costBaseTower;
    [SerializeField] private CostBuilding costBaseWoodBuilding;
    [SerializeField] private CostBuilding costBaseOreStoneBuilding;
    [SerializeField] private CostBuilding costBaseBarracksBuilding;
    [SerializeField] private CostBuilding costBaseOreGoldBuilding;
    [SerializeField] private GameObject noticeResourceTab;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI invalidText;
    [SerializeField] private GameObject invalidNotice;
    private BuildingType buildingType;
    private void Start()
    {
        buildingChoice.SetActive(false);
        noticeResourceTab.SetActive(false);
        invalidNotice.SetActive(false);
    }
    public void CloseTab()
    {
        buildingChoice.SetActive(false);
    }
    public void CloseResourceNotiTab()
    {
        noticeResourceTab?.SetActive(false);
    }

    public void OpenTab()
    {
        buildingChoice.SetActive(true);
    }

    public void BuildFarmerHouse()
    {
        SetTextForNoticeResourcec(costBaseFarmerBuilding.BaseStone, costBaseFarmerBuilding.BaseGold, costBaseFarmerBuilding.BaseWood);
        buildingType = BuildingType.FarmerHouse;
        noticeResourceTab.SetActive(true);
    }
    public void BuildOreStoneHouse()
    {
        SetTextForNoticeResourcec(costBaseOreStoneBuilding.BaseStone, costBaseOreStoneBuilding.BaseGold, costBaseOreStoneBuilding.BaseWood);
        buildingType = BuildingType.OreStoneHouse;
        noticeResourceTab.SetActive(true);
    }
    public void BuildOreGoldHouse()
    {
        SetTextForNoticeResourcec(costBaseOreGoldBuilding.BaseStone, costBaseOreGoldBuilding.BaseGold, costBaseOreGoldBuilding.BaseWood);
        buildingType = BuildingType.OreGoldHouse;
        noticeResourceTab.SetActive(true);
    }
    public void BuildBarracksHouse()
    {
        SetTextForNoticeResourcec(costBaseBarracksBuilding.BaseStone, costBaseBarracksBuilding.BaseGold, costBaseBarracksBuilding.BaseWood);
        buildingType = BuildingType.BarracksHouse;
        noticeResourceTab.SetActive(true);
    }
    public void BuildTowerDefenseHouse()
    {
        SetTextForNoticeResourcec(costBaseTower.BaseStone, costBaseTower.BaseGold, costBaseTower.BaseWood);
        buildingType = BuildingType.Tower;
        noticeResourceTab.SetActive(true);
    }
    public void BuildWoodHouse()
    {
        SetTextForNoticeResourcec(costBaseWoodBuilding.BaseStone, costBaseWoodBuilding.BaseGold, costBaseWoodBuilding.BaseWood);
        buildingType = BuildingType.WoodHouse;
        noticeResourceTab.SetActive(true);
    }

    private bool checkValidToBuilding(BuildingType type)
    {
        int availableStone = GameManager.Instance.currentStone;
        int availableGold = GameManager.Instance.currentGold;
        int availableWood = GameManager.Instance.currentWood;
        int currentBuilding;
        switch (type)
        {
            case BuildingType.BarracksHouse:
                currentBuilding = GameManager.Instance.currentBarracks + 1;
                if(currentBuilding <= GameManager.Instance.numberOfBarracksMaxInLevel)
                {
                    int currentStone = availableStone - costBaseBarracksBuilding.BaseStone;
                    int currentGold = availableGold - costBaseBarracksBuilding.BaseGold;
                    int currentWood = availableWood - costBaseBarracksBuilding.BaseWood;
                    if(currentStone >= 0 &&  currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentBarracks += 1;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
            case BuildingType.Tower:
                currentBuilding = GameManager.Instance.currentTower + 1;
                if(currentBuilding <= GameManager.Instance.numberOfTowerMaxInLevel)
                {
                    int currentStone = availableStone - costBaseTower.BaseStone;
                    int currentGold = availableGold - costBaseTower.BaseGold;
                    int currentWood = availableWood - costBaseTower.BaseWood;
                    if (currentStone >= 0 && currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentTower = currentBuilding;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
            case BuildingType.WoodHouse:
                currentBuilding = GameManager.Instance.currentWoodHouse + 1;
                if(currentBuilding <= GameManager.Instance.numberOfWoodHouseMaxInLevel)
                {
                    int currentStone = availableStone - costBaseWoodBuilding.BaseStone;
                    int currentGold = availableGold - costBaseWoodBuilding.BaseGold;
                    int currentWood = availableWood - costBaseWoodBuilding.BaseWood;
                    if (currentStone >= 0 && currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentWoodHouse = currentBuilding;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
            case BuildingType.OreStoneHouse:
                currentBuilding = GameManager.Instance.currentOreStone + 1;
                if(currentBuilding <= GameManager.Instance.numberOfOreStoneHouseMaxInLevel)
                {
                    int currentStone = availableStone - costBaseOreStoneBuilding.BaseStone;
                    int currentGold = availableGold - costBaseOreStoneBuilding.BaseGold;
                    int currentWood = availableWood - costBaseOreStoneBuilding.BaseWood;
                    if (currentStone >= 0 && currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentOreStone = currentBuilding;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
            case BuildingType.OreGoldHouse:
                currentBuilding = GameManager.Instance.currentOreGold + 1;
                if(currentBuilding <= GameManager.Instance.numberOfOreGoldHouseMaxInLevel)
                {
                    int currentStone = availableStone - costBaseOreGoldBuilding.BaseStone;
                    int currentGold = availableGold - costBaseOreGoldBuilding.BaseGold;
                    int currentWood = availableWood - costBaseOreGoldBuilding.BaseWood;
                    if (currentStone >= 0 && currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentOreGold = currentBuilding;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
            case BuildingType.FarmerHouse:
                currentBuilding = GameManager.Instance.currentFarmerHouse + 1;
                if(currentBuilding <= GameManager.Instance.numberOfFarmerHouseMaxInLevel)
                {
                    int currentStone = availableStone - costBaseFarmerBuilding.BaseStone;
                    int currentGold = availableGold - costBaseFarmerBuilding.BaseGold;
                    int currentWood = availableWood - costBaseFarmerBuilding.BaseWood;
                    if (currentStone >= 0 && currentGold >= 0 && currentWood >= 0)
                    {
                        GameManager.Instance.currentFarmerHouse = currentBuilding;
                        GameManager.Instance.currentStone = currentStone;
                        GameManager.Instance.currentWood = currentWood;
                        GameManager.Instance.currentGold = currentGold;
                        return true;
                    }
                    invalidText.text = "You don't have enough resources to build this building";
                }
                else
                {
                    invalidText.text = "Your building has reached the maximum number in this level";
                }
                break;
        }
        return false;
    }

    public void CreateBuilding()
    {
        bool isValid = checkValidToBuilding(buildingType);
        if (isValid)
        {
            Debug.Log("Hop le de xay nha");
            ManageBuilding manage = FindAnyObjectByType<ManageBuilding>();
            manage.CreateBuilding(buildingSprites[(int)buildingType], buildingType);
            GameManager.Instance.UpdateUI();
            CloseResourceNotiTab();
            CloseTab();
        }
        else
        {
            invalidNotice.SetActive(true);
        }
    }
    public void CloseInvalidNotice()
    {
        invalidNotice.SetActive(false);
    }
    private void SetTextForNoticeResourcec(float stone, float gold, float wood)
    {
        goldText.text = gold.ToString();
        stoneText.text = stone.ToString();
        woodText.text = wood.ToString();
    }
}
