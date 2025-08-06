using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;
    public float speed = 3f;

    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex >= pathPoints.Length) return;
        
        Transform target = pathPoints[currentIndex];
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f) { currentIndex++;}
    }
}
