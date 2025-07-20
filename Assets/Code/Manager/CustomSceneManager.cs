using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Unity 내장 클래스인 SceneManager가 존재하기 때문에 이름을 이렇게 지음.

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance { get; private set; }

    private Animator black_cover_anim;

    private void Awake()
    {
        transform.parent = null; // 이걸 안하면, Game Managers (Empty GameObject)를 쓸 수 없음.
        ConfigSingleton();
        GetReferences();
    }

    private void Start()
    {
        black_cover_anim.SetTrigger("Become Transparent");
    }

    private void ConfigSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void GetReferences()
    {
        black_cover_anim = GetComponentInChildren<Animator>();
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadScene_(index));
    }

    IEnumerator LoadScene_(int index)
    {
        black_cover_anim.SetTrigger("Become Opaque");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(index);
        yield return new WaitForSeconds(0.25f);
        black_cover_anim.SetTrigger("Become Transparent");

        yield break;
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}