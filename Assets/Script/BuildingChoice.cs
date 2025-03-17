using Assets.Entity;
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
    [SerializeField] private CostBuilding costBaseOreBuilding;
    [SerializeField] private CostBuilding costBaseBarracksBuilding;
    private void Start()
    {
        buildingChoice.SetActive(false);
    }
    public void CloseTab()
    {
        buildingChoice.SetActive(false);    
    }
    public void OpenTab()
    {
        buildingChoice.SetActive(true);
    }

    public void BuildFarmerHouse()
    {

    }

}
