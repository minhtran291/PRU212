using System.Collections.Generic;
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

    public GameObject farmerPrefab;
    public GameObject soldierPrefab;
    public GameObject carpenterPrefab;
    public GameObject minerPrefab;

    public Transform spawnPoint;

    private List<GameObject> farmerList = new List<GameObject>();
    private List<GameObject> soldierList = new List<GameObject>();
    private List<GameObject> carpenterList = new List<GameObject>();
    private List<GameObject> minerList = new List<GameObject>();

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

    // ham chung de tao doi tuong
    private GameObject SpawnCharacter(GameObject prefab, List<GameObject> list)
    {
        GameObject newObj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        list.Add(newObj); 
        return newObj;
    }

    // ham chung de xoa doi tuong
    private void RemoveCharacter(List<GameObject> list)
    {
        if (list.Count > 0)
        {
            GameObject objToRemove = list[list.Count - 1]; // lay doi tuong cuoi cung
            list.RemoveAt(list.Count - 1); // xoa khoi danh sach
            Destroy(objToRemove); // huy doi tuong
        }
    }

    // tang sl dan
    public void IncreaseFarmer()
    {
        if (unsignedCount > 0 && totalCount > 0)
        {
            farmerCount++;
            unsignedCount--;
            signedCount++;

            SpawnCharacter(farmerPrefab, farmerList);
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

            SpawnCharacter(soldierPrefab, soldierList);
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

            SpawnCharacter(carpenterPrefab, carpenterList);
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

            SpawnCharacter(minerPrefab, minerList);
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

            RemoveCharacter(farmerList);
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

            RemoveCharacter(soldierList);
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

            RemoveCharacter(carpenterList);
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

            RemoveCharacter(minerList);
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
