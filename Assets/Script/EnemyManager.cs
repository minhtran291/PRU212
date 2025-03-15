using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandle();
    }
    private void MoveHandle()
    {
        Vector2 move = transform.right;
        rb.linearVelocity = move.normalized*moveSpeed*Time.deltaTime;
    }
   
}
