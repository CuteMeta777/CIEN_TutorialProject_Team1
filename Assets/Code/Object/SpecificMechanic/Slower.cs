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
        if (ps == null) { Debug.Log("Player가 PlayerStatus 컴포넌트를 지니고 있지 않습니다!"); return; }

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

        // 어짜피 여기까지 올 수도 없는데, 그 이유는 무조건 초기 조건이 Slight이기 때문. [SF] 최고!
    }
}