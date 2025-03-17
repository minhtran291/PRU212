using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private float hpBase = 200f;
    [SerializeField] private Image hpBar;
    [SerializeField] private float currentHp;
    private float maxHp;
    void Start()
    {
        maxHp = hpBase*level;
        currentHp = maxHp;
        UpdateHpBar();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Max(0, currentHp - damage);
        UpdateHpBar();
        if(currentHp <= 0)
        {
            Die();
        }

    }
    private void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHp/maxHp;
        }
    }
    private void Die()
    {
        GameObject.Destroy(gameObject);
    }
}
