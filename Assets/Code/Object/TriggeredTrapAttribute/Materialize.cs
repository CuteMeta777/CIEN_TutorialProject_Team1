using UnityEngine;

// 처음엔 안 보였다가 특정-구역(=Detector)에 들어오면 보이게 만드는 것.
public class Materialize : TriggeredTrap
{
    private MeshRenderer[] mrs;
    private SkinnedMeshRenderer[] smrs;

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
        smrs = GetComponentsInChildren<SkinnedMeshRenderer>();
        // Debug.Log(mrs);
        foreach (SkinnedMeshRenderer smr in smrs) Debug.Log(smr);
    }

    private void BecomeInvisible()
    {
        if (mrs != null) { foreach (MeshRenderer mr in mrs) mr.enabled = false; }
        if (smrs != null) { foreach (SkinnedMeshRenderer smr in smrs) { Debug.Log(smr); smr.enabled = false; } }
    }

    public override void React()
    {
        // add particle effect later
        if (mrs != null) { foreach (MeshRenderer mr in mrs) mr.enabled = true; }
        if (smrs != null) { foreach (SkinnedMeshRenderer smr in smrs) smr.enabled = true; }
    }
}