using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static GameObject data_manager;
    public Data data;

    private void Awake()
    {
        transform.parent = null; // �̰� ���ϸ�, Game Managers (Empty GameObject)�� �� �� ����.
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
        // �ʱ�ȭ��
        ResetData();
        SaveToJson();
        // �ʱ�ȭ�� (�������)
        LoadFromJson();
    }

    /*private void OnApplicationQuit() // ������ ������������ ����� ��쿡�� �����͸� ŵ.
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
        if (File.Exists(filePath) == false) // ���� ���ڰų�, ������ ó�� �⵿�� �����.
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