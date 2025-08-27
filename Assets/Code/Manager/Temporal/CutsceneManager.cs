using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    private Image image;

    [SerializeField] private Image cutscene_black_cover;
    [SerializeField] private Sprite[] cutscenes;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        for (int i = 0; i < cutscenes.Length; i++)
        {
            for (float j = 0f; j <= 1f; j += 0.0078125f) { cutscene_black_cover.color = new Color(0f, 0f, 0f, j); yield return null; }
            image.sprite = cutscenes[i];
            for (float j = 1f; j >= 0f; j -= 0.0078125f) { cutscene_black_cover.color = new Color(0f, 0f, 0f, j); yield return null; }
            yield return new WaitForSeconds(2f);
        }
        CustomSceneManager.instance.GoToNextScene();
        yield break;
    }
}