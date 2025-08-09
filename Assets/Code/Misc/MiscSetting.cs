using UnityEngine;

public class MiscSetting : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60; // framerate stabilizer
        ConfigThirdPersonMousePointer();
    }

    private void ConfigThirdPersonMousePointer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}