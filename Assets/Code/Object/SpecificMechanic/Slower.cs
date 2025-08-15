using UnityEngine;

public class Slower : MonoBehaviour
{
    [SerializeField] private PlayerStatus.Effect effect_type;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStatus ps = other.GetComponent<PlayerStatus>();
        if (ps == null) { Debug.Log("Player가 PlayerStatus 컴포넌트를 지니고 있지 않습니다!"); return; }
        ps.ApplyEffect(effect_type);
    }
}