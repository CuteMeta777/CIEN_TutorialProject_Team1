using UnityEngine;

public class Goal : MonoBehaviour
{
    private AudioSource ap;

    [SerializeField] private ParticleSystem confetti_particle;

    private void Start()
    {
        ap = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player가 PlayerAction 컴포넌트를 지니고 있지 않습니다!"); return; }

        confetti_particle.Play();
        ap.Play();
        pa.ReachedGoal();
    }
}