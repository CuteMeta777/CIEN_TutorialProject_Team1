using UnityEngine;

public class Goal : MonoBehaviour
{
    // 어짜피 따로 골대가 존재하는 것이 아닌, 특정 구역이 Goal이 될 것이므로, Trigger로 설정함. 그러나 기획이 바뀐다면 빠르게 수정 ㄱㄱ
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        pa.ReachedGoal();
        return;
    }
}