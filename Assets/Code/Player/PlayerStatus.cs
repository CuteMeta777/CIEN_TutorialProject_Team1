using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public float base_speed { get; private set; }
    [SerializeField, Tooltip("Default = 30")] private float _base_speed;
    public float jump_force { get; private set; }
    [SerializeField, Tooltip("Default = 150")] private float _jump_force;
    public float vel_damp { get; private set; }
    [SerializeField, Range(0.05f, 0.95f), Tooltip("Default = 0.75")] private float _velocity_damp;

    public float speed_multi { get; private set; }
    public float jump_force_multi { get; private set; }

    public bool is_grounded { get; private set; } public void SetIsGrounded(bool value) { is_grounded = value; }

    public enum Effect
    {
        SlightSlowDown,
        StrongSlowDown
    }
    private Coroutine slight_slow_down;
    private Coroutine strong_slow_down;

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        base_speed = _base_speed;
        jump_force = _jump_force;
        vel_damp = _velocity_damp;

        speed_multi = 1f;

        slight_slow_down = null;
        strong_slow_down = null;
    }

    public void ApplyEffect(Effect effect_type)
    {
        if (effect_type == Effect.SlightSlowDown) 
        {
            if (slight_slow_down == null) slight_slow_down = StartCoroutine(SlightSlowDown());
            // else { StopCoroutine(slight_slow_down); StartCoroutine(SlightSlowDown()); }
            return;
        }
        if (effect_type == Effect.StrongSlowDown)
        {
            if (strong_slow_down == null) strong_slow_down = StartCoroutine(StrongSlowDown());
            // else { StopCoroutine(strong_slow_down); StartCoroutine(StrongSlowDown()); }
            return;
        }
    }

    IEnumerator SlightSlowDown()
    {
        speed_multi -= 0.25f;
        yield return new WaitForSeconds(1f);
        speed_multi += 0.25f;
        yield break;
    }

    IEnumerator StrongSlowDown()
    {
        speed_multi -= 0.5f;
        yield return new WaitForSeconds(1f);
        speed_multi += 0.5f;
        yield break;
    }
}