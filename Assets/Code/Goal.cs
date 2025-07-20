using UnityEngine;

public class Goal : MonoBehaviour
{
    // ��¥�� ���� ��밡 �����ϴ� ���� �ƴ�, Ư�� ������ Goal�� �� ���̹Ƿ�, Trigger�� ������. �׷��� ��ȹ�� �ٲ�ٸ� ������ ���� ����
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        pa.ReachedGoal();
        return;
    }
}