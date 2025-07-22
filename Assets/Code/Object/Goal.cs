using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player�� PlayerAction ������Ʈ�� ���ϰ� ���� �ʽ��ϴ�!"); return; }

        pa.ReachedGoal();
    }
}