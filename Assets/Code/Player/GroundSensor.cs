using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerAction pa;

    // [SerializeField] private ParticleSystem land_particle; ���Ŀ� �߰��� ����... (+���嵵)

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        pa = GetComponentInParent<PlayerAction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (pa == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        // land_particle.Play();
        pa.SetIsGrounded(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (pa == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        pa.SetIsGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (pa == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        pa.SetIsGrounded(false);
    }
}