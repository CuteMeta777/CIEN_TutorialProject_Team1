using UnityEngine;
using Unity.Cinemachine;

public class SavePoint : MonoBehaviour
{
    private AudioSource ap;
    private CinemachineOrbitalFollow cof;

    [SerializeField] private ParticleSystem confetti_particle;
    [SerializeField, Range(0, 360), Tooltip("Default = 0")] private float mouse_tibegging_direction_x, mouse_tibegging_direction_y;

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        ap = GetComponent<AudioSource>();
        cof = FindFirstObjectByType<CinemachineOrbitalFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // transform.rotation = Quaternion.Euler(45, 45, 45); // 나중엔 깃발(?)같은 걸로 Animation을 적용할 거지만, 일단은 작동되는지만 테스트해보기 위함.
        confetti_particle.Play();
        ap.Play();
        cof.HorizontalAxis.Value = mouse_tibegging_direction_x;
        cof.VerticalAxis.Value = mouse_tibegging_direction_y;
        SavePointManager.instance.SetLastSavePoint(transform.position);
    }
}