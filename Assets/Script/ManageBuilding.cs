using Assets.Enum;
using Assets.Script;
using UnityEngine;

public class ManageBuilding : MonoBehaviour
{
    [SerializeField] private BuildingChoice manage;
    [SerializeField] private GameObject buildingPrefabs;
    private GameObject selectedPlace;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                selectedPlace = hit.collider.gameObject;
                HandleSpriteClick();
                
                

            }
        }
    }

    private void HandleSpriteClick()
    {
        manage.OpenTab();
    }
    public void CreateBuilding(Sprite sprite, BuildingType type)
    {
        if (selectedPlace == null)
        {
            Debug.LogError("selectedPlace is null! Không thể tạo building.");
            return;
        }
        Debug.Log("Parent of selectedPlace: " + selectedPlace.transform.parent.name);
        Vector3 spawnPosition = selectedPlace.transform.position;
        GameObject newBuilding = Instantiate(buildingPrefabs, spawnPosition, Quaternion.identity);
        newBuilding.GetComponent<SpriteRenderer>().sprite = sprite;
        newBuilding.name = type.ToString();   
        Building building =  newBuilding.AddComponent<Building>();
        building.Type = type;
        newBuilding.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        Destroy(selectedPlace);
    }

}
