using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private enum Type
    {
        InstaKill
    }
    [SerializeField] private Type type;

    // Obstacle�� Trigger�� ��� (�ַ� ����)
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player�� PlayerAction ������Ʈ�� ���ϰ� ���� �ʽ��ϴ�!"); return; }

        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }

        Debug.Log("�߸��� Type�� ���� Obstacle�� �����մϴ�! (ID : " + gameObject.GetInstanceID() + ")");
    }

    // Obstacle�� Rigid-Body Object�� ��� (�ַ� ������ �״� ���� ���ڿ� ���� ��?)
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerAction pa = other.gameObject.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player�� PlayerAction ������Ʈ�� ���ϰ� ���� �ʽ��ϴ�!"); return; }

        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }

        Debug.Log("�߸��� Type�� ���� Obstacle�� �����մϴ�! (ID : " + gameObject.GetInstanceID() + ")");
    }
}