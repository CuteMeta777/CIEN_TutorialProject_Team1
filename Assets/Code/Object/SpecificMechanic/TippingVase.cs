using UnityEngine;
using System.Collections;

// 특정-구역(=Detector)에 들어오면...
public class TippingVase : TriggeredTrap
{
    [SerializeField] private ParticleSystem break_particle;
    [SerializeField] private GameObject debrid;

    public override void React()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.Rotate(0, 0, -3f);
            yield return null;
        }

        break_particle.Play();
        MeshRenderer[] mrs = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mr in mrs) mr.enabled = false;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 10; i++)
            Instantiate(debrid, transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0, -0.5f + Random.Range(-0.25f, 0.25f)), Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f)));
        Destroy(gameObject);
        yield break;
    }
}