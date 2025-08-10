using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        WeakSlowdown,
        StrongSlowdown
    }
    private Dictionary<Effect, float> effect_durations = new Dictionary<Effect, float>();

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
        jump_force_multi = 1f;
    }

    public void ApplyEffect(Effect type)
    {
        switch (type)
        {
            case Effect.WeakSlowdown:
                ApplySlowdown(0.25f);
                break;
            case Effect.StrongSlowdown:
                ApplySlowdown(0.50f);
                break;
        }
    }

    private void ApplySlowdown(float strength)
    {
        float weak_slowdown_duration = 1f;
        float new_end_time = Time.time + weak_slowdown_duration;

        // already have the effect, so just add "end time"
        if (effect_durations.ContainsKey(Effect.WeakSlowdown))
        {
            effect_durations[Effect.WeakSlowdown] = new_end_time;
            return;
        }

        // start new coroutine, if doesn't have the effect yet
        effect_durations[Effect.WeakSlowdown] = new_end_time;
        StartCoroutine(Slowdown(strength));
    }

    private IEnumerator Slowdown(float strength)
    {
        speed_multi -= strength;

        while (Time.time < effect_durations[Effect.WeakSlowdown])
        {
            yield return null;
        }

        speed_multi += strength;
        effect_durations.Remove(Effect.WeakSlowdown);
    }
}