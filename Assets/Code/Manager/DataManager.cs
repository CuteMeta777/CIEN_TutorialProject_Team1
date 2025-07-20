using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static GameObject data_manager;
    public Data data;

    private void Awake()
    {
        transform.parent = null; // 이걸 안하면, Game Managers (Empty GameObject)를 쓸 수 없음.
        ConfigSingleton();
    }

    private void ConfigSingleton()
    {
        if (data_manager == null)
        {
            data_manager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        data = new Data();
        // 초기화용
        ResetData();
        SaveToJson();
        // 초기화용 (여기까지)
        LoadFromJson();
    }

    /*private void OnApplicationQuit() // 게임이 비정상적으로 종료된 경우에도 데이터를 킵.
    {
        SaveToJson();
    }*/

    public void SaveToJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        File.WriteAllText(filePath, JsonUtility.ToJson(data));
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        if (File.Exists(filePath) == false) // 운이 나쁘거나, 게임을 처음 기동한 경우임.
        {
            ResetData();
            return;
        }
        data = JsonUtility.FromJson<Data>(File.ReadAllText(filePath));
    }

    public void ResetData()
    {
        data.cleared_levels = 0;
    }

    public void ClearedLevel()
    {
        data.cleared_levels++;
    }
}

// [System.Serializable]
public class Data
{
    public int cleared_levels;
}