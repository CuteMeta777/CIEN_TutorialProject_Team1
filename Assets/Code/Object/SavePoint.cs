using UnityEngine;
using Unity.Cinemachine;
using Benjathemaker;

public class SavePoint : MonoBehaviour
{
    private AudioSource ap;
    private CinemachineOrbitalFollow cof;
    private SimpleGemsAnim sga;

    private bool is_already_activated;

    [SerializeField] private ParticleSystem confetti_particle;
    [SerializeField, Range(0, 360), Tooltip("Default = 0")] private float mouse_tibegging_direction_x, mouse_tibegging_direction_y;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void InitFields()
    {
        is_already_activated = false;
    }

    private void GetReferences()
    {
        ap = GetComponent<AudioSource>();
        cof = FindFirstObjectByType<CinemachineOrbitalFollow>();
        sga = GetComponent<SimpleGemsAnim>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (is_already_activated) return;
        if (!other.CompareTag("Player")) return;

        is_already_activated = true;
        sga.isRotating = false;
        confetti_particle.Play();
        ap.Play();
        cof.HorizontalAxis.Value = mouse_tibegging_direction_x;
        cof.VerticalAxis.Value = mouse_tibegging_direction_y;
        SavePointManager.instance.SetLastSavePoint(transform.position);
    }
}