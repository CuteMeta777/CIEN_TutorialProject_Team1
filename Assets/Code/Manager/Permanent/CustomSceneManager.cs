using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CustomSceneManager : MonoBehaviour // Unity ���� Ŭ������ SceneManager�� �����ϱ� ������ �̸��� �̷��� ����.
{
    public static CustomSceneManager instance { get; private set; }

    private Animator black_cover_anim;
    private Coroutine load_scene_coroutine;

    private void Awake()
    {
        transform.parent = null; // �̰� ���ϸ�, Game Managers (Empty GameObject)�� �� �� ����.
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

    // ���� ���� �̷��� ¥�� �� �ǰ�, �ʿ��� ������ ���ȭ�ؼ� ��Ȯ�ϰ� �ؾ� ��. ��ġ�� �ϴ� �׽�Ʈ��... cutscene������ ��������� �ʾ����Ƿ�.
    public void GoToNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8) { LoadScene(1); return; }

        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}