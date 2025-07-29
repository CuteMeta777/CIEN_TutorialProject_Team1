using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerAction pa;

    // [SerializeField] private ParticleSystem land_particle; 추후에 추가할 예정... (+사운드도)

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
        if (pa == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        // land_particle.Play();
        pa.SetIsGrounded(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (pa == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        pa.SetIsGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (pa == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        pa.SetIsGrounded(false);
    }
}