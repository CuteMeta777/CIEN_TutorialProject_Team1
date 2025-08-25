using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private AudioSource ap; // audio player

    [SerializeField] private RectTransform child_text_rect_transform;

    private void Start()
    {
        ap = GetComponent<AudioSource>();
    }

    public void MoveTextUp()
    {
        child_text_rect_transform.offsetMax = new Vector2(0, 0);
    }

    public void MoveTextDown()
    {
        ap.Play();
        child_text_rect_transform.offsetMax = new Vector2(0, -25);
    }
}