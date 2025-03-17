using UnityEngine;

public class ManageBuilding : MonoBehaviour
{
    [SerializeField] private BuildingChoice manage;
    [SerializeField] private Sprite sprite;
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
                HandleSpriteClick(selectedPlace);
            }
        }
    }

    private void HandleSpriteClick(GameObject clickedObject)
    {
        selectedPlace.GetComponent<SpriteRenderer>().sprite = sprite;
        manage.OpenTab();
    }
}
