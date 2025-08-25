using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    [SerializeField] private RectTransform child_text_rect_transform;

    public void MoveTextUp()
    {
        child_text_rect_transform.offsetMax = new Vector2(0, 0);
    }

    public void MoveTextDown()
    {
        child_text_rect_transform.offsetMax = new Vector2(0, -25);
    }
}