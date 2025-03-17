using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseBuilding : MonoBehaviour
{

    public GameObject housePrefab;
    public Tilemap tilemap;
    public Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPosition = tilemap.WorldToCell(mouseWorldPosition); 

            TileBase clickedTile = tilemap.GetTile(gridPosition); 

            if (clickedTile != null) 
            {
                Vector3 buildPosition = tilemap.GetCellCenterWorld(gridPosition);

                Instantiate(housePrefab, new Vector3(buildPosition.x, buildPosition.y, 0), Quaternion.identity);
            }
        }
    }
}
