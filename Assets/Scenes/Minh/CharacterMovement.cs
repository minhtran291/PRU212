using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // toc do di chuyen
    private Vector2 targetPosition; // Vi tri muc tieu di chuyen den
    void Start()
    {
        ChooseNewTarget(); // chon vi tri ngau nhien ban dau
    }

    // Update is called once per frame
    void Update()
    {
        // di chuyen doi tuong den vi tri muc tieu
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // khi den gan vi tri muc tieu chon vi tri moi
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            ChooseNewTarget();
        }
    }

    void ChooseNewTarget()
    {
        float randomX = Random.Range(-5f, 5f); // gioi han pham vi di chuyen X
        float randomY = Random.Range(-5f, 5f); // gioi han pham vi di chuyen Y

        targetPosition = new Vector2(randomX, randomY); // cap nhat vi tri ngau nhien
    }
}
