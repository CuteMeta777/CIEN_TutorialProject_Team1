using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoveFlame : MonoBehaviour
{
    private ParticleSystem flame_particle;
    private Collider damage_space;

    private float timer;

    [SerializeField] private float inflame_duration;
    [SerializeField] private float rest_duration;
    [SerializeField] private Image cooldown_UI;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        StartCoroutine(Work());
    }

    private void Update()
    {
        UpdateCooldownUI();
    }

    private void UpdateCooldownUI()
    {
        float prop = (Time.time - timer) / rest_duration;
        cooldown_UI.fillAmount = prop;
        cooldown_UI.color = new Color(1f, 1f - prop, 1f - prop);
    }

    private void GetReferences()
    {
        flame_particle = GetComponent<ParticleSystem>();
        damage_space = GetComponent<Collider>();
        cooldown_UI = GetComponentInChildren<Image>();
    }

    IEnumerator Work()
    {
        while (true)
        {
            flame_particle.Play();
            damage_space.enabled = true;
            yield return new WaitForSeconds(inflame_duration);
            flame_particle.Stop();
            damage_space.enabled = false;
            timer = Time.time;
            yield return new WaitForSeconds(rest_duration);
        }
    }
}