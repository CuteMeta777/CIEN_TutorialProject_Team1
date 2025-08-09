using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerStatus ps;

    // [SerializeField] private ParticleSystem land_particle; ���Ŀ� �߰��� ����... (+���嵵)

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        ps = GetComponentInParent<PlayerStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        // land_particle.Play();
        ps.SetIsGrounded(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        ps.SetIsGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor�� �������� ���� Player GameObject�� �����մϴ�!"); return; }

        ps.SetIsGrounded(false);
    }
}