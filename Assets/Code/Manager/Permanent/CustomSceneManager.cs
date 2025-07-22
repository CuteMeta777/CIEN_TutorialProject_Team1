using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CustomSceneManager : MonoBehaviour // Unity 내장 클래스인 SceneManager가 존재하기 때문에 이름을 이렇게 지음.
{
    public static CustomSceneManager instance { get; private set; }

    private Animator black_cover_anim;
    private Coroutine load_scene_coroutine;

    private void Awake()
    {
        transform.parent = null; // 이걸 안하면, Game Managers (Empty GameObject)를 쓸 수 없음.
        ConfigSingleton();
        GetReferences();
        InitFields();
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

    private void InitFields()
    {
        load_scene_coroutine = null;
    }

    public void LoadScene(int index)
    {
        if (load_scene_coroutine != null) return;
        load_scene_coroutine = StartCoroutine(LoadScene_Coroutine(index));
    }

    IEnumerator LoadScene_Coroutine(int index)
    {
        black_cover_anim.SetTrigger("Become Opaque");
        yield return new WaitForSeconds(0.25f);

        AsyncOperation async_load = SceneManager.LoadSceneAsync(index);
        while (!async_load.isDone)
            yield return null;
        
        yield return new WaitForSeconds(0.25f);
        black_cover_anim.SetTrigger("Become Transparent");

        load_scene_coroutine = null;
        yield break;
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}