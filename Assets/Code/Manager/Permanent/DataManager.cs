using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }

    public Data data;

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

    private void Start()
    {
        data = new Data();
        LoadFromJson();
    }

    private void OnApplicationQuit() // +������ ������������ ����� ��쿡�� �����͸� ŵ.
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
        if (File.Exists(filePath) == false || string.IsNullOrEmpty(File.ReadAllText(filePath))) // ���� ���ڰų�, ������ ó�� �⵿�� �����.
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