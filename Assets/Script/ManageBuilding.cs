using UnityEngine;
using UnityEngine.Tilemaps;

public class ManageBuilding : MonoBehaviour
{
    [SerializeField] private BuildingChoice manage;
    [SerializeField] private Tilemap tilemap; // Gán Tilemap từ Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0; 
            Vector3Int tilePosition = tilemap.WorldToCell(worldPosition);
            TileBase clickedTile = tilemap.GetTile(tilePosition);
            if (clickedTile != null)
            {
                HandleTileClick(clickedTile, tilePosition);
            }
        }
    }

    private void HandleTileClick(TileBase clickedTile, Vector3Int tilePosition)
    {
        manage.OpenTab();
    }
}
