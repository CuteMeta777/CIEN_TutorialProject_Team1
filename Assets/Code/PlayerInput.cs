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

        // ������ ���۰��� ���� GetAxisRaw�� ���. ��ɾ��� ���۰��� ���Ѵٸ� GetAxis. ���� GetAxis�� ����Ѵٸ�, Animation�� �ε巯����.
        move_x = Input.GetAxisRaw("Horizontal");
        move_z = Input.GetAxisRaw("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);
        attack = Input.GetMouseButton(0);
    }
}