using UnityEngine;  
using System.Collections;

public class TitleAnimator : MonoBehaviour
{
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        StartCoroutine(Pulsing());
    }

    IEnumerator Pulsing()
    {
        while (true)
        {
            for (float i = 0.95f; i <= 1.05f; i += 0.00078125f)
            {
                rt.localScale = new Vector3(i, i, 1f);
                yield return null;
            }
            for (float i = 1.05f; i >= 0.95f; i -= 0.00078125f)
            {
                rt.localScale = new Vector3(i, i, 1f);
                yield return null;
            }
        }
    }
}