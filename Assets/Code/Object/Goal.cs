using UnityEngine;

public class Goal : MonoBehaviour
{
    private AudioSource ap;

    private bool is_already_activated;

    [SerializeField] private ParticleSystem confetti_particle;

    private void Start()
    {
        is_already_activated = false;
        ap = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (is_already_activated) return;
        if (!other.CompareTag("Player")) return;

        is_already_activated = true;
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player가 PlayerAction 컴포넌트를 지니고 있지 않습니다!"); return; }

        confetti_particle.Play();
        ap.Play();
        pa.ReachedGoal();
    }
}