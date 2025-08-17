using UnityEngine;

public class Fall : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float dispawn_time;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void GetReferences()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        // add particle effect later
        rb.isKinematic = false;
        rb.useGravity = true;
        Destroy(gameObject, dispawn_time);
    }
}