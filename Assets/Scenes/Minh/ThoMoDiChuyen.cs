using Pathfinding;
using System.Collections;
using TMPro;
using UnityEngine;

public class ThoMoDiChuyen : MonoBehaviour
{
    public float moveSpeed = 2f;
    public double khoangCach = 1.5;

    private Transform NhaDa;
    private Transform MoDa;

    private AIPath aiPath;
    private Transform target;

    private bool isCollecting = false;
    public TextMeshProUGUI stoneMessagePrefab;
    private TextMeshProUGUI stoneMessageInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        NhaDa = GameObject.Find("NhaDa")?.transform;
        MoDa = GameObject.Find("MoDa")?.transform;

        SetNewTarget(MoDa);

        if (stoneMessagePrefab != null)
        {
            stoneMessageInstance = Instantiate(stoneMessagePrefab, GameObject.Find("Canvas").transform);
        }
        stoneMessageInstance.gameObject.SetActive(false);
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

        if (target == MoDa)
        {
            yield return new WaitForSeconds(5f);
            SetNewTarget(NhaDa);
        }
        else if (target == NhaDa)
        {
            ShowStoneMessage("+50 stone");
            yield return new WaitForSeconds(1f);
            SetNewTarget(MoDa);
        }
        isCollecting = false;
    }

    void ShowStoneMessage(string message)
    {
        stoneMessageInstance.text = message;
        stoneMessageInstance.gameObject.SetActive(true);

        stoneMessageInstance.transform.position = NhaDa.position;

        StartCoroutine(MoveMessageUp());
    }

    IEnumerator MoveMessageUp()
    {
        Vector3 startPosition = stoneMessageInstance.transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, 2, 0);

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            stoneMessageInstance.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        stoneMessageInstance.gameObject.SetActive(false);
    }
}
