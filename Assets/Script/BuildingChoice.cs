using UnityEngine;

public class BuildingChoice : MonoBehaviour
{
    [SerializeField] GameObject buildingChoice;

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
}
