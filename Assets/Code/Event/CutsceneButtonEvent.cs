using UnityEngine;

public class CutsceneButtonEvent : MonoBehaviour
{
    public void Skip()
    {
        CustomSceneManager.instance.GoToNextScene();
    }
}