using UnityEngine;

// ���� ���� ���������� ���� ���� ���� ������? �ƴϸ� �ڵ�� �������� �κ��� ������ ������?
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