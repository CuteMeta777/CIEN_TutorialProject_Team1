using UnityEngine;

public class MainMenuButtonEvent : MonoBehaviour
{
    private DataManager dm;
    private CustomSceneManager csm;

    private int starting_index;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        dm = FindFirstObjectByType<DataManager>();
        csm = FindAnyObjectByType<CustomSceneManager>();
    }

    private void InitFields()
    {
        starting_index = 1;
    }

    public void StartGame()
    {
        Debug.Log("starting index : " + starting_index);
        Debug.Log("dm.data.cleared_levels" + dm.data.cleared_levels);
        csm.LoadScene(starting_index + dm.data.cleared_levels);
    }

    public void Quit()
    {
        Application.Quit();
    }
}