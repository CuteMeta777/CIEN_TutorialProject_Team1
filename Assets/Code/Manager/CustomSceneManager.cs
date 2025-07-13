using UnityEngine;
using UnityEngine.SceneManagement;

// Unity 내장 클래스인 SceneManager가 존재하기 때문에 이름을 이렇게 지음.
// 아마 나중에 FadeIn~Out을 구현할 듯...

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance { get; private set; }

    private void Awake()
    {
        transform.parent = null; // 이걸 안하면, Game Managers (Empty GameObject)를 쓸 수 없음.
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