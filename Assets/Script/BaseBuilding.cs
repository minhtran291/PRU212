using UnityEngine;
using UnityEngine.UI;

public class BaseBuilding : MonoBehaviour
{
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
