using UnityEngine;

public class MainMenuButtonEvent : MonoBehaviour
{
    private int scene_offset;

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        scene_offset = 2;
    }

    public void Play()
    {
        CustomSceneManager.instance.LoadScene(scene_offset + DataManager.instance.data.cleared_levels);
    }

    public void Quit()
    {
        Application.Quit();
    }
}