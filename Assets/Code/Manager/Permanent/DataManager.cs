using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }

    public Data data;

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

    private void Start()
    {
        data = new Data();
        LoadFromJson();
    }

    private void OnApplicationQuit() // +게임이 비정상적으로 종료된 경우에도 데이터를 킵.
    {
        SaveToJson();
    }

    private void SaveToJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        File.WriteAllText(filePath, JsonUtility.ToJson(data));
    }

    private void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        if (File.Exists(filePath) == false || string.IsNullOrEmpty(File.ReadAllText(filePath))) // 운이 나쁘거나, 게임을 처음 기동한 경우임.
        {
            ResetData();
            SaveToJson();
            return;
        }
        data = JsonUtility.FromJson<Data>(File.ReadAllText(filePath));
    }

    private void ResetData()
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