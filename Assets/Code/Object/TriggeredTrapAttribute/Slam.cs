using UnityEngine;

// Ư��-����(=Detector)�� ������ ������� ��.
public class Slam : TriggeredTrap
{
    private Rigidbody rb;

    [SerializeField] private Vector3 slamming_direction;
    [SerializeField] private float slamming_force;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        SimulationEnabled(false);
    }

    private void GetReferences()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void SimulationEnabled(bool value)
    {
        rb.isKinematic = (!value);
    }

    public override void React()
    {
        SimulationEnabled(true);
        rb.AddForce(slamming_direction.normalized * slamming_force);
    }
}