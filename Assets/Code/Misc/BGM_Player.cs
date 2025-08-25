using UnityEngine;

public class BGM_Player : MonoBehaviour
{
    private AudioSource ap;

    private void Start()
    {
        ap = GetComponent<AudioSource>();
        ap.Play();
    }
}