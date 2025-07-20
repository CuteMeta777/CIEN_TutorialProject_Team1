using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ���� �з����� �� �������� ����... �ٵ� �з����� ���������� �ϴ� �� �̰� ���ؼ� �����ϴ� �ͺ��ٴ� �׳� Rigidbody�� �ϴ� �� ��������?

    private enum Type
    {
        InstaKill,
        Knockback
    }
    [SerializeField] private Type type;

    // Obstacle�� Trigger�� ��� (�ַ� ����)
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        if (type == Type.Knockback)
        {
            pa.Hurt();
            return;
        }

        Debug.Log("�߸��� Type�� ���� Obstacle�� �����մϴ�! (ID : " + gameObject.GetInstanceID() + ")");
    }

    // Obstacle�� Rigid-Body Object�� ��� (�ַ� ������ �״� ���� ���ڿ� ���� ��?)
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        if (type == Type.Knockback)
        {
            pa.Hurt();
            return;
        }

        Debug.Log("�߸��� Type�� ���� Obstacle�� �����մϴ�! (ID : " + gameObject.GetInstanceID() + ")");
    }
}