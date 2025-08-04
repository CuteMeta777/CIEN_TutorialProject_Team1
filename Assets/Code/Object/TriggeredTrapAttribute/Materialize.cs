using UnityEngine;

// ó���� �� �����ٰ� Ư��-����(=Detector)�� ������ ���̰� ����� ��.
public class Materialize : TriggeredTrap
{
    private MeshRenderer[] mrs;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        BecomeInvisible();
    }

    private void GetReferences()
    {
        mrs = GetComponentsInChildren<MeshRenderer>();
    }

    private void BecomeInvisible()
    {
        foreach (MeshRenderer mr in mrs) mr.enabled = false;
    }

    public override void React()
    {
        // add particle effect later
        foreach (MeshRenderer mr in mrs) mr.enabled = true;
    }
}