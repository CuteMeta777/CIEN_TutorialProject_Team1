using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public PathData pathData;
    public float speed = 1.0f;
    public float arriveThreshold = 0.1f;

    int idx;
    Vector3[] runtimePoints;
    Vector3 originPos;
    Quaternion originRot;

    void Awake()
    {
        if (pathData == null || pathData.points == null || pathData.points.Length == 0)
        {
            enabled = false;
            return;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (idx >= runtimePoints.Length) return;

        Vector3 target = datat.useLocalSpace ? originPos + (originRot * runtimePoints[idx]) : runtimePoints[idx];

        Vector3 to = target - transform.position;
        float dist = to.magnitude;
        if (dist <= arriveThreshold)
            {
                idx++; return;
            }


        Vector3 step = to.normalized*speed*Time.deltaTime;
        transform.position += (step.sqrMagnitude > dist * dist) ? to : step;
    }

    void OnDrawGizomsSelected()
    {
        if (pathData == null || pathData.points == null) return;

        Vector3 ToWorld(Vector3 p) => pathData.useLocalSpace ? tranform.position + (transform.rotation * p) : p;
        for (int i = 0;i< pathData.points.Length; i++)
        {
            Vector3 a = ToWorld(pathData.points[i]);
            Gizmos.DrawSphere(a, 0.05f);
            if (i + 1 < pathData.points.Length)
            {
                Vector3 b = ToWorld(pathData.points[i + 1]);
                Gizmos.DrawLine(a, b);
            }
        }
    }

}
