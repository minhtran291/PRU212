using Pathfinding;
using UnityEngine;

public class LinhDiChuyen : MonoBehaviour
{
    public float moveSpeed = 2f;
    public double khoangCach = 0.7;

    public Transform TuongTren;
    public Transform TuongTrai;
    public Transform TuongDuoi;
    public Transform TuongPhai;

    private AIPath aiPath;
    private Transform target;
    private int linhID;
    private static int linhCounter = CallMuaDan.soldierCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        linhID = linhCounter;
        linhCounter++;

        target = GetAssignedTarget();
        SetNewTarget(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiPath.pathPending && Vector3.Distance(transform.position, target.position) <= khoangCach)
        {
            aiPath.canMove = false;
        }
        Debug.Log("Distance to target: " + Vector3.Distance(transform.position, target.position));
        Debug.Log("AI reached destination: " + (Vector3.Distance(transform.position, target.position) <= khoangCach));
    }

    Transform GetAssignedTarget()
    {
        int targetIndex = linhID % 4;
        switch (targetIndex)
        {
            case 0: return TuongTrai;
            case 1: return TuongTren;
            case 2: return TuongDuoi;
            case 3: return TuongPhai;
            default: return TuongTrai;
        }
    }

    void SetNewTarget(Transform newTarget)
    {
        aiPath.destination = newTarget.position;
        aiPath.SearchPath();
    }
}
