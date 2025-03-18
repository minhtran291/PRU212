using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 8f;
    public int damage = 10;
    [SerializeField] public float fireRate = 60f;
    [SerializeField] private CircleCollider2D attackRangeCollider;

    private List<EnemyManager> enemiesInRange = new List<EnemyManager>();

    //void Start()
    //{
    //    SetupCollider();
    //    StartCoroutine(ShootRoutine());
    //}

    //void SetupCollider()
    //{
    //    attackRangeCollider = GetComponent<CircleCollider2D>();
    //    attackRangeCollider.radius = range;
    //    attackRangeCollider.isTrigger = true;
    //}

    //IEnumerator ShootRoutine()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f / fireRate);
    //        CleanEnemiesList();

    //        if (enemiesInRange.Count > 0)
    //        {
    //            EnemyManager target = GetFirstValidEnemy();
    //            if (target != null) target.TakeDamage(damage);
    //        }
    //    }
    //}

    //void CleanEnemiesList()
    //{
    //    // Remove enemies that are null, dead, or out of range
    //    enemiesInRange.RemoveAll(enemy => enemy == null || !enemy.IsAlive());
    //}

    //EnemyManager GetFirstValidEnemy()
    //{
    //    foreach (EnemyManager enemy in enemiesInRange)
    //    {
    //        if (enemy != null && enemy.IsAlive())
    //            return enemy;
    //    }
    //    return null;
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.TryGetComponent<EnemyManager>(out EnemyManager enemy) && !enemiesInRange.Contains(enemy))
    //    {
    //        enemiesInRange.Add(enemy);
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.TryGetComponent<EnemyManager>(out EnemyManager enemy))
    //    {
    //        enemiesInRange.Remove(enemy);
    //    }
    //}

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //    if (health <= 0) Destroy(gameObject);
    //}
}
