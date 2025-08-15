using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoveFlame : MonoBehaviour
{
    private ParticleSystem flame_particle;
    private Collider damage_space;

    private float timer;

    [SerializeField] private float initial_rest_duration;
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

    private void GetReferences()
    {
        flame_particle = GetComponent<ParticleSystem>();
        damage_space = GetComponent<Collider>();
        cooldown_UI = GetComponentInChildren<Image>();
    }

    IEnumerator Work()
    {
        flame_particle.Stop();
        damage_space.enabled = false;
        cooldown_UI.fillAmount = 0f;
        yield return new WaitForSeconds(initial_rest_duration);

        timer = Time.time;
        StartCoroutine(Infinite_UpdateCooldownUI());
        while (true)
        {
            flame_particle.Stop();
            damage_space.enabled = false;
            timer = Time.time;
            yield return new WaitForSeconds(rest_duration);
            flame_particle.Play();
            damage_space.enabled = true;
            yield return new WaitForSeconds(inflame_duration);
        }
    }

    IEnumerator Infinite_UpdateCooldownUI()
    {
        float prop = 0f;

        while (true)
        {
            prop = (Time.time - timer) / rest_duration;
            cooldown_UI.fillAmount = prop;
            cooldown_UI.color = new Color(1f, 1f - prop, 1f - prop);
            yield return null;
        }
    }
}