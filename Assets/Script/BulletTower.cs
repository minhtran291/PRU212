using UnityEngine;

public class BulletTower : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform target;
    private int damage;

    void Start()
    {
        // Load sprite từ Resources
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("PlayerBullet");
    }

    public void SetTarget(Transform target, int damage, float speed)
    {
        this.target = target;
        this.damage = damage;
        this.speed = speed;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.transform == target)
        {
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
