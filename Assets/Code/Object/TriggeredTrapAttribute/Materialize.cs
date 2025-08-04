using UnityEngine;

// 처음엔 안 보였다가 특정-구역(=Detector)에 들어오면 보이게 만드는 것.
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