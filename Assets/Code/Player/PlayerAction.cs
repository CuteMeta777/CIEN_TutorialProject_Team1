using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerInput pi;
    private PlayerStatus ps;
    private Rigidbody rb;
    private Animator anim;

    [SerializeField, Tooltip("Const value. DO NOT TOUCH")] private Transform cam_transform;

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        MoveToLastSavePoint();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        AimCamera();
        anim.SetBool("IsGrounded", ps.is_grounded);
        if (pi.jump && ps.is_grounded) Jump();
    }

    private void AimCamera()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cam_transform.eulerAngles.y, transform.eulerAngles.x);
    }

    private void MoveToLastSavePoint()
    {
        transform.position = SavePointManager.instance.GetLastSavePoint();
    }

    private void GetReferences()
    {
        pi = GetComponent<PlayerInput>();
        ps = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Move()
    {
        anim.SetFloat("Velocity", Mathf.Sign(pi.move_x) * new Vector2(pi.move_x, pi.move_z).normalized.magnitude);
        Vector3 move_dir = (transform.right * pi.move_x + transform.forward * pi.move_z).normalized;
        rb.linearVelocity += move_dir * ps.speed_multi * ps.base_speed * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * ps.vel_damp, rb.linearVelocity.y, rb.linearVelocity.z * ps.vel_damp);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * ps.jump_force);
    }

    public void Hurt()
    {
        // ������� ���� �ð�^^
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Hurt") || state.IsName("Die") || state.IsName("Goal")) return;

        anim.SetTrigger("Hurt");
    }

    public void Die()
    {
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Die") || state.IsName("Goal")) return;

        anim.SetTrigger("Die");
    }

    public void ReachedGoal()
    {
        // Unity ���� ������ ���� �ʴ´�...
        // �׾����� �� ������, ��ģ ���¿����� ��������� ��뿡 ���� ������...
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Goal") || state.IsName("Die")) return;

        anim.SetTrigger("Goal");
    }
}