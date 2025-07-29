using UnityEngine;

public class Ground : MonoBehaviour
{
    private void Start()
    {
        SetTag("Ground");
    }

    private void SetTag(string tag_name)
    {
        gameObject.tag = tag_name;
    }
}