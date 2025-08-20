using Unity.Cinemachine;
using UnityEngine;

public class InitialCatAimManager : MonoBehaviour
{
    private CinemachineOrbitalFollow cof;

    [SerializeField, Range(0, 360), Tooltip("Default = 0")] private float initial_direction;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        cof.HorizontalAxis.Value = initial_direction;
    }

    private void GetReferences()
    {
        cof = FindFirstObjectByType<CinemachineOrbitalFollow>();
    }
}