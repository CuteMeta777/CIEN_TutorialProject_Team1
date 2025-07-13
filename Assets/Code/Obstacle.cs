using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ���� �з����� �� �������� ����...

    private enum Type
    {
        InstaKill,
        Knockback
    }
    [SerializeField] private Type type;

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