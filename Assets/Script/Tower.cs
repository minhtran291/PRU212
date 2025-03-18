using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 8f;
    public int damage = 10;
    [SerializeField] public float fireRate = 1f;
    [SerializeField] private GameObject bulletPrefab;
    private Transform firePoint;
    private List<EnemyManager> enemiesInRange = new List<EnemyManager>();
    private float fireCooldown = 0f;

    void Awake()
    {
        firePoint = transform;

        // Load prefab từ Resources nếu chưa gán trong Inspector
        if (bulletPrefab == null)
        {
            bulletPrefab = Resources.Load<GameObject>("BulletTower");
        }
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f && enemiesInRange.Count > 0)
        {
            EnemyManager target = GetClosestEnemy();
            if (target != null)
            {
                Shoot(target);
                fireCooldown = 1f / fireRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }

    private EnemyManager GetClosestEnemy()
    {
        if (enemiesInRange.Count == 0) return null;

        EnemyManager closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var enemy in enemiesInRange)
        {
            if (enemy == null) continue;
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    private void Shoot(EnemyManager target)
    {
        if (target == null || bulletPrefab == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        BulletTower bulletScript = bullet.GetComponent<BulletTower>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(target.transform, damage, 5f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f); // Red
        Gizmos.DrawSphere(transform.position, range);
    }
}
