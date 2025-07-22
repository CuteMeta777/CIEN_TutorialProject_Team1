using Unity.Cinemachine;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CinemachineInputAxisController ciac;

    public float move_x { get; private set; }
    public float move_z { get; private set; }
    public bool jump { get; private set; }
    private bool is_active;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        ciac = FindFirstObjectByType<CinemachineInputAxisController>();
    }

    private void InitFields()
    {
        move_x = 0;
        move_z = 0;
        jump = false;
        is_active = true;
    }

    private void ResetInputValues()
    {
        move_x = 0;
        move_z = 0;
        jump = false;
    }

    private void Update()
    {
        if (!is_active) { ResetInputValues(); return; }
        
        move_x = Input.GetAxisRaw("Horizontal");
        move_z = Input.GetAxisRaw("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    public void Enabled(bool value)
    {
        is_active = value;
        ciac.enabled = value;
    }
}