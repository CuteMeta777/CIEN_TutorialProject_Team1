using UnityEngine;

public class Ground : MonoBehaviour
{
    private void Start()
    {
        SetLayer("Ground");
    }

    private void SetLayer(string layer_name)
    {
        int is_layer_valid = LayerMask.NameToLayer(layer_name);
        if (is_layer_valid == -1)
        {
            Debug.Log("잘못된 레이어 이름을 적은 Script가 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
            return;
        }
        gameObject.layer = LayerMask.NameToLayer(layer_name);
    }
}