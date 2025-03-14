using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallMuaDan : MonoBehaviour
{
    public GameObject panel;

    public int farmerCount = 0; // nong dan
    public int soldierCount = 0; // linh
    public int carpenterCount = 0; // tho moc
    public int minerCount = 0; // tho mo

    public int unsignedCount = 5; // chua gan
    public int signedCount = 0; // da gan
    public int totalCount = 5; // sl tong

    public TextMeshProUGUI farmerText;
    public TextMeshProUGUI soldierText;
    public TextMeshProUGUI carpenterText;
    public TextMeshProUGUI minerText;

    public TextMeshProUGUI unsignedText;
    public TextMeshProUGUI signedText;
    public TextMeshProUGUI totalText;

    public Button increaseFarmerButton, decreaseFarmerButton;
    public Button increaseSoldierButton, decreaseSoldierButton;
    public Button increaseCarpenterButton, decreaseCarpenterButton;
    public Button increaseMinerButton, decreaseMinerButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }

    // tang sl nhan
    public void IncreaseFarmer()
    {
        if (unsignedCount > 0 && totalCount > 0)
        {
            farmerCount++;
            unsignedCount--;
            signedCount++;
        }
        UpdateUI();
        //Debug.Log(farmerCount);
    }
    public void IncreaseSoldier()
    {
        if (unsignedCount > 0 && totalCount > 0)
        {
            soldierCount++;
            unsignedCount--;
            signedCount++;
        }
        UpdateUI();
    }
    public void IncreaseCarpenter()
    {
        if (unsignedCount > 0 && totalCount > 0)
        {
            carpenterCount++;
            unsignedCount--;
            signedCount++;
        }
        UpdateUI();
    }
    public void IncreaseMiner()
    {
        if (unsignedCount > 0 && totalCount > 0)
        {
            minerCount++;
            unsignedCount--;
            signedCount++;
        }
        UpdateUI();
    }

    // giam sl nhan vat
    public void DecreaseFarmer()
    {
        if (farmerCount > 0)
        {
            farmerCount--;
            unsignedCount++;
            signedCount--;
        }
        UpdateUI();
    }
    public void DecreaseSoldier()
    {
        if (soldierCount > 0)
        {
            soldierCount--;
            unsignedCount++;
            signedCount--;
        }
        UpdateUI();
    }
    public void DecreaseCarpenter()
    {
        if (carpenterCount > 0)
        {
            carpenterCount--;
            unsignedCount++;
            signedCount--;
        }
        UpdateUI();
    }
    public void DecreaseMiner()
    {
        if (minerCount > 0)
        {
            minerCount--;
            unsignedCount++;
            signedCount--;
        }
        UpdateUI();
    }


    // update display sl nhan vat ui
    void UpdateUI()
    {
        farmerText.text = farmerCount.ToString();
        soldierText.text = soldierCount.ToString();
        carpenterText.text = carpenterCount.ToString();
        minerText.text = minerCount.ToString();

        unsignedText.text = unsignedCount.ToString();
        signedText.text = signedCount.ToString() + "/" + totalCount.ToString();
        //totalText.text = totalCount.ToString();

        // disable + if unsignedCount = 0
        bool canIncrease = unsignedCount > 0;
        increaseFarmerButton.interactable = canIncrease;
        increaseSoldierButton.interactable = canIncrease;
        increaseCarpenterButton.interactable = canIncrease;
        increaseMinerButton.interactable = canIncrease;


        // disable - if sl nhan vat = 0
        decreaseFarmerButton.interactable = farmerCount > 0;
        decreaseSoldierButton.interactable = soldierCount > 0;
        decreaseCarpenterButton.interactable = carpenterCount > 0;
        decreaseMinerButton.interactable = minerCount > 0;
    }
}
