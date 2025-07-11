using UnityEngine;

public class StaticPlatform : MonoBehaviour
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
            Debug.Log("�߸��� ���̾� �̸��Դϴ�! (ID : " + gameObject.GetInstanceID() + ")");
            return;
        }
        gameObject.layer = LayerMask.NameToLayer("Ground");
    }
}