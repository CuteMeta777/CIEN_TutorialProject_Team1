using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform target;
    public float viewDistance = 10f;// �þ� ���� 10m(����Ƽ �⺻ ť�� 10�� �̾� ���� ����)
    public float viewAngle = 180f;//�¿� �þ߰� 90��
    public float moveSpeed = 5f;
    public float raycastDistance = 2f;
    public bool lockedOn = false;
    public Vector3 dir = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Move(Vector3 inputDirection)
    {
        if (inputDirection != Vector3.zero) { transform.position += inputDirection.normalized * moveSpeed * Time.deltaTime; }
        else { return; }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 directionToTarget = target.position - transform.position;

        Move(dir);

        float distance = directionToTarget.magnitude;
        if (distance > viewDistance) return;

        float angle = Vector3.Angle(transform.forward, directionToTarget);//Forward means +z direction of the object in scene view
        if (angle > viewAngle / 2f) return;

        if (!Physics.Raycast(transform.position, directionToTarget.normalized, out RaycastHit hit, viewDistance)) return;
        if (!hit.transform.CompareTag("Player")) return;

        if (!lockedOn)
        {
            dir = directionToTarget;
            lockedOn = true;
        }
    }
}
