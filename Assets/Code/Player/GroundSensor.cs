using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerAction pa;
    private PlayerStatus ps;
    private AudioSource ap; // audio player

    private float timestamp;

    [SerializeField] private ParticleSystem walk_particle, land_particle;
    [SerializeField] private AudioClip land_clip;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        pa = GetComponentInParent<PlayerAction>();
        ps = GetComponentInParent<PlayerStatus>();
        ap = GetComponent<AudioSource>();
    }
    private void InitFields()
    {
        timestamp = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        land_particle.Play();
        ap.PlayOneShot(land_clip);
        ps.SetIsGrounded(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        if (Mathf.Abs(pa.rb.linearVelocity.x) > 0.125f && Time.time - timestamp > 0.125f) { timestamp = Time.time; walk_particle.Play(); }
        ps.SetIsGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground")) return;
        if (ps == null) { Debug.Log("Ground Sensor가 부착되지 않은 Player GameObject가 존재합니다!"); return; }

        ps.SetIsGrounded(false);
    }
}