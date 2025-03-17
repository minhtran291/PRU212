using Pathfinding;
using System.Collections;
using TMPro;
using UnityEngine;

public class DanDiChuyen : MonoBehaviour
{
    public float moveSpeed = 2f;
    public double khoangCach = 1.5;

    private Transform NhaDan;
    private Transform Ruong;

    private AIPath aiPath;
    private Transform target;

    private bool isCollecting = false;
    public TextMeshProUGUI meatMessagePrefab;
    private TextMeshProUGUI meatMessageInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        NhaDan = GameObject.Find("NhaDan")?.transform;
        Ruong = GameObject.Find("Ruong")?.transform;

        SetNewTarget(Ruong);

        if (meatMessagePrefab != null)
        {
            meatMessageInstance = Instantiate(meatMessagePrefab, GameObject.Find("Canvas").transform);
        }
        meatMessageInstance.gameObject.SetActive(false);
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

        if (target == Ruong)
        {
            yield return new WaitForSeconds(5f);
            SetNewTarget(NhaDan);
        }
        else if (target == NhaDan)
        {
            ShowStoneMessage("+50 meat");
            yield return new WaitForSeconds(1f);
            SetNewTarget(Ruong);
        }
        isCollecting = false;
    }

    void ShowStoneMessage(string message)
    {
        meatMessageInstance.text = message;
        meatMessageInstance.gameObject.SetActive(true);

        meatMessageInstance.transform.position = NhaDan.position;

        StartCoroutine(MoveMessageUp());
    }

    IEnumerator MoveMessageUp()
    {
        Vector3 startPosition = meatMessageInstance.transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, 2, 0);

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            meatMessageInstance.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        meatMessageInstance.gameObject.SetActive(false);
    }
}
