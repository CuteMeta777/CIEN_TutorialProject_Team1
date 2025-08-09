using UnityEngine;

public class Slower : MonoBehaviour
{
    private enum SlowType
    {
        Slight,
        Strong
    }
    [SerializeField] private SlowType type;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStatus ps = other.GetComponent<PlayerStatus>();
        if (ps == null) { Debug.Log("Player�� PlayerStatus ������Ʈ�� ���ϰ� ���� �ʽ��ϴ�!"); return; }

        if (type == SlowType.Slight)
        {
            ps.ApplyEffect(PlayerStatus.Effect.SlightSlowDown);
            return;
        }
        if (type == SlowType.Strong)
        {
            ps.ApplyEffect(PlayerStatus.Effect.StrongSlowDown);
            return;
        }

        // ��¥�� ������� �� ���� ���µ�, �� ������ ������ �ʱ� ������ Slight�̱� ����. [SF] �ְ�!
    }
}