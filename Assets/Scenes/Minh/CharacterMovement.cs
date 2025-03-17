using System.Collections;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // toc do di chuyen
    private Vector2 targetPosition; // Vi tri muc tieu
    private bool isMoving = true; // kiem tra xem doi tuong co dang di hay ko
    void Start()
    {
        targetPosition = new Vector2(-10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false; 
                StartCoroutine(WaitAndChooseNewTarget()); 
            }
        }
    }

    IEnumerator WaitAndChooseNewTarget()
    {
        yield return new WaitForSeconds(5f);

        if (targetPosition.x == -10f)
        {
            targetPosition = new Vector2(-1.5f, 0f); 
        }
        else
        {
            targetPosition = new Vector2(-10f, 0f); 
        }

        isMoving = true; 
    }

}

