using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePointManager : MonoBehaviour
{
    public static SavePointManager instance;

    [SerializeField] private Vector3 lastest_save_point; public void SetLastSavePoint(Vector3 position) { lastest_save_point = position; } public Vector3 GetLastSavePoint() { return lastest_save_point; }
    private string[] valid_scene_names = new string[3];

    private void Awake()
    {
        transform.parent = null; // �̰� ���ϸ�, Game Managers (Empty GameObject)�� �� �� ����.
        ConfigSingleton();
        InitFields();
        SetInitialPositionForPlayer(); // ���� ��Ŀ���� ��, Start�� ���� ������, PlayerAction class�� MoveToLastSavePoint ������ �ε����ϰ� �̰����� �ű�.
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < valid_scene_names.Length; i++)
            if (scene.name == valid_scene_names[i]) return;

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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

    private void InitFields()
    {
        valid_scene_names[0] = "Stage 1";
        valid_scene_names[1] = "Stage 2";
        valid_scene_names[2] = "Stage 3";
    }

    private void SetInitialPositionForPlayer()
    {
        if (SceneManager.GetActiveScene().name == "Stage 1") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
        if (SceneManager.GetActiveScene().name == "Stage 2") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
        if (SceneManager.GetActiveScene().name == "Stage 3") { lastest_save_point = new Vector3(4.6f, 0.98f, -0.032f); return; }
    }
}