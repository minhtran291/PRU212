using Pathfinding;
using System.Collections;
using TMPro;
using UnityEngine;

public class Testmove : MonoBehaviour
{

    public float moveSpeed = 2f;
    public double khoangCach = 1.5;
    //private Transform home;
    private Transform lumberCamp;
    //private Transform forest;
    private Transform cayTrenTrai;

    private AIPath aiPath;
    private Transform target;
    private bool isCollecting = false;

    public TextMeshProUGUI woodMessagePrefab;
    private TextMeshProUGUI woodMessageInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        //home = GameObject.Find("Home")?.transform;
        lumberCamp = GameObject.Find("NhaGo")?.transform;
        //forest = GameObject.Find("ForeGround")?.transform;
        cayTrenTrai = GameObject.Find("CayGocTrenTrai").transform;

        SetNewTarget(cayTrenTrai);

        if (woodMessagePrefab != null)
        {
            woodMessageInstance = Instantiate(woodMessagePrefab, GameObject.Find("Canvas").transform);
            //woodMessageInstance.text = "ko co gi";
        }
        woodMessageInstance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiPath.pathPending && !isCollecting && Vector3.Distance(transform.position, target.position) <= khoangCach)
        {
            StartCoroutine(WaitAndChooseNewTarget());
        }
        Debug.Log("Distance to target: " + Vector3.Distance(transform.position, target.position));
        Debug.Log("AI reached destination: " + (Vector3.Distance(transform.position, target.position) <= khoangCach));
        Debug.Log(woodMessageInstance.text);
        Debug.Log(woodMessageInstance.transform.position);
        //Debug.Log(woodMessageText.text);
    }

    void SetNewTarget(Transform newTarget)
    {
        target = newTarget;
        aiPath.destination = newTarget.position;
        aiPath.SearchPath();
    }

    IEnumerator WaitAndChooseNewTarget()
    {
        isCollecting = true;

        if (target == cayTrenTrai)
        {
            yield return new WaitForSeconds(5f);
            SetNewTarget(lumberCamp);
        }
        else if (target == lumberCamp)
        {
            ShowWoodMessage("+50 wood");
            yield return new WaitForSeconds(1f);
            SetNewTarget(cayTrenTrai);
        }
        isCollecting = false;
    }

    void ShowWoodMessage(string message)
    {
        woodMessageInstance.text = message;
        woodMessageInstance.gameObject.SetActive(true);

        woodMessageInstance.transform.position = lumberCamp.position;

        StartCoroutine(MoveMessageUp());
    }

    IEnumerator MoveMessageUp()
    {
        Vector3 startPosition = woodMessageInstance.transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, 2, 0); 

        float duration = 2f;  
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            woodMessageInstance.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        woodMessageInstance.gameObject.SetActive(false);
    }
}
