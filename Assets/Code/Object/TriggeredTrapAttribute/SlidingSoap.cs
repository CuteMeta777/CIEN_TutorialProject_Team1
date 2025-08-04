using UnityEngine;

// 길을 따라 내려오도록 직접 길을 만들 것인지? 아니면 코드로 물리적인 부분을 제어할 것인지?
public class SlidingSoap : TriggeredTrap
{
    private Rigidbody rb;

    private bool is_already_activated;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void Start()
    {
        SimulationEnabled(false);
    }

    private void GetReferences()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void InitFields()
    {
        is_already_activated = false;
    }

    private void SimulationEnabled(bool value)
    {
        rb.isKinematic = (!value);
    }

    public override void React()
    {
        if (is_already_activated) return;

        is_already_activated = true;
        SimulationEnabled(true);
    }
}