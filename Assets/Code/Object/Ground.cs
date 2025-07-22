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
            Debug.Log("�߸��� ���̾� �̸��� ���� Script�� �����մϴ�! (ID : " + gameObject.GetInstanceID() + ")");
            return;
        }
        gameObject.layer = LayerMask.NameToLayer(layer_name);
    }
}