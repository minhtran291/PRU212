using UnityEngine;

public class TowerPlacementManager : MonoBehaviour
{
    public GameObject towerPrefab;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero); 

            if (hit.collider != null && hit.collider.CompareTag("TowerPlace")) 
            {
                Vector3 placePosition = hit.collider.bounds.center;
                PlaceTower(placePosition);
            }
        }
    }

    private void PlaceTower(Vector3 position)
    {
        if (GameManager.Instance != null && GameManager.Instance.currentStone >= 50)
        {
            GameManager.Instance.SpendStoneForTowerLv1(50);
            Instantiate(towerPrefab, position, Quaternion.identity);
            Debug.Log("Tháp đã được đặt tại: " + position);
        }
        else
        {
            Debug.Log("Không đủ tài nguyên đá.");
        }
    }
}
