using System.Collections;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // toc do di chuyen
    private Vector2 targetPosition; // Vi tri muc tieu
    private bool isMoving = true; // kiem tra xem doi tuong co dang di hay ko
    void Start()
    {
        // dat vi tri ban dau
        targetPosition = new Vector2(-10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // di chuyen doi tuong ve phia muc tieu
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // kiem tra den gan muc tieu hay chua
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false; // dung khi den muc tieu
                StartCoroutine(WaitAndChooseNewTarget()); // cho 10 giay va chon muc tieu moi
            }
        }
    }

    IEnumerator WaitAndChooseNewTarget()
    {
        // cho 10 giay
        yield return new WaitForSeconds(5f);

        if (targetPosition.x == -10f)
        {
            targetPosition = new Vector2(-1.5f, 0f); // dat muc tieu quay lai -1.5
        }
        else
        {
            targetPosition = new Vector2(-10f, 0f); // dat muc tieu la -10
        }

        // neu muc tieu hien tai la -10 quay lai -1.5
        isMoving = true; // bat dau di chuyen muc tieu moi
    }

}

