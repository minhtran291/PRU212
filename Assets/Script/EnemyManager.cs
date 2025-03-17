using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speedAttack = 0.9f;
    private float nextAttack;
    private Rigidbody2D rb;
    private Transform target;
    [SerializeField] private int level = 1;
    [SerializeField] private float hpBase = 200f;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameObject hpBarContainer;
    [SerializeField] public float currentHp;
    private float maxHp;
    private bool isUnderAttack = false;
    void Start()
    {
        maxHp = hpBase * level;
        currentHp = maxHp;
        UpdateHpBar();
        if (hpBarContainer != null)
        {
            hpBarContainer.SetActive(false);
        }
        rb = GetComponent<Rigidbody2D>();
        FindClosestTarget();
    }

    void Update()
    {
        MoveHandle();
    }

    private void MoveHandle()
    {
        if (target == null)
        {
            FindClosestTarget();
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time < nextAttack) return;
        nextAttack = Time.time + speedAttack;

        if (collision.gameObject.CompareTag("Walls"))
        {
            WallController wallController = collision.gameObject.GetComponent<WallController>();
            if (wallController != null)
            {
                wallController.TakeDamage(damage);
                if (wallController.currentHp <= 0)
                {
                    FindClosestTarget();
                }
            }
        }
        else if (collision.gameObject.CompareTag("Building"))
        {
            var building = collision.gameObject.GetComponent<BaseBuilding>();
            if (building != null)
            {
                Debug.Log("building======");
                building.TakeDamage(damage);
                if (building.currentHp <= 0)
                {
                    FindClosestTarget(); 
                }
            }
        }else if (collision.gameObject.CompareTag("Base"))
        {
            var baseHouse = collision.gameObject.GetComponent<BaseHouseManager>();
            baseHouse.TakeDamage(damage);
            
        }
    }

    private void FindClosestTarget()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Walls");
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        GameObject baseBuilding = GameObject.FindGameObjectWithTag("Base");

        List<GameObject> allTargets = new List<GameObject>();
        allTargets.AddRange(walls);
        allTargets.AddRange(buildings);

        if (allTargets.Count == 0 && baseBuilding != null)
        {
            target = baseBuilding.transform;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject obj in allTargets)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = obj.transform;
            }
        }

        if (closestTarget != null)
        {
            Debug.Log(closestTarget.name);
            target = closestTarget;
        }
    }
    public void TakeDamage(float damage)
    {
        if (!isUnderAttack)
        {
            ShowHpBar();
        }

        currentHp = Mathf.Max(0, currentHp - damage);
        UpdateHpBar();

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    private void Die()
    {
        GameObject.Destroy(gameObject);
    }

    public void ShowHpBar()
    {
        if (hpBarContainer != null)
        {
            hpBarContainer.SetActive(true);
            isUnderAttack = true;
        }
    }

    public void HideHpBar()
    {
        if (hpBarContainer != null)
        {
            hpBarContainer.SetActive(false);
            isUnderAttack = false;
        }
    }

}
