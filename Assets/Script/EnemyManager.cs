using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speedAttack = 0.9f;
    private float nextAttack;
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            WallController wallController = collision.gameObject.GetComponent<WallController>();
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + speedAttack;
                wallController.TakeDamage(damage);
            }

        }
    }
}
