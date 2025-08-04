using UnityEngine;

// 추상 클래스와 협업
public class Detector : MonoBehaviour
{
    private TriggeredTrap[] receivers;

    private bool is_already_activated;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (is_already_activated) return;
        if (!other.CompareTag("Player")) return;

        is_already_activated = true;
        foreach (TriggeredTrap entity in receivers) { entity.React(); }
    }

    private void GetReferences()
    {
        receivers = GetComponentsInParent<TriggeredTrap>();
    }

    private void InitFields()
    {
        is_already_activated = false;
    }
}