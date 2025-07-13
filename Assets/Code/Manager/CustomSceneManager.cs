using UnityEngine;
using UnityEngine.SceneManagement;

// Unity ���� Ŭ������ SceneManager�� �����ϱ� ������ �̸��� �̷��� ����.
// �Ƹ� ���߿� FadeIn~Out�� ������ ��...

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance { get; private set; }

    private void Awake()
    {
        transform.parent = null; // �̰� ���ϸ�, Game Managers (Empty GameObject)�� �� �� ����.
        ConfigSingleton();
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

    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}