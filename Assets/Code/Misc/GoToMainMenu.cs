using UnityEngine;

// bootstrap ����. ������ ���.
public class GoToMainMenu : MonoBehaviour
{
    private void Start()
    {
        int main_menu_scene_index = 1;
        CustomSceneManager.instance.LoadScene(main_menu_scene_index);
    }
}