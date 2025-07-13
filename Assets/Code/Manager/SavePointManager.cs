using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePointManager : MonoBehaviour
{
    public static SavePointManager instance;
    private Vector3 lastest_save_point; // position

    private void Awake()
    {
        transform.parent = null; // 이걸 안하면, Game Managers (Empty GameObject)를 쓸 수 없음.
        ConfigSingleton();
    }

    private void Start()
    {
        SetInitialPositionForPlayer();
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

    private void SetInitialPositionForPlayer()
    {
        if (SceneManager.GetActiveScene().name == "Stage 1") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
        if (SceneManager.GetActiveScene().name == "Stage 2") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
        if (SceneManager.GetActiveScene().name == "Stage 3") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
    }

    public void SetLastSavePoint(Vector3 position) { lastest_save_point = position; }
    public Vector3 GetLastSavePoint() { return lastest_save_point; }
}