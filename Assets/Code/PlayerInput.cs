using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float move_x { get; private set; }
    public float move_z { get; private set; }
    public bool jump { get; private set; }
    public bool attack { get; private set; }

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        move_x = 0;
        move_z = 0;
        jump = false;
        attack = false;
    }

    private void Update()
    {
        // if (GameManager.game_over) { InitFields(); return; }

        // 정직한 조작감을 위해 GetAxisRaw를 사용. 양심없는 조작감을 원한다면 GetAxis. 또한 GetAxis를 사용한다면, Animation도 부드러워짐.
        move_x = Input.GetAxisRaw("Horizontal");
        move_z = Input.GetAxisRaw("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);
        attack = Input.GetMouseButton(0);
    }
}