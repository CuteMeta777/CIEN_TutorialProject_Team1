using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerInput pi;
    private Rigidbody rb;
    private Animator anim;

    [SerializeField] private float move_speed; // default = 30
    [SerializeField] private float jump_force; // default = 150
    [SerializeField] private float vel_damp;   // default = 0.75 (감속 비율이므로 0 < x < 1이여야 함)
    private bool is_grounded; public void SetIsGrounded(bool value) { is_grounded = value; }

    [SerializeField] private Transform cam_transform; // DO NOT TOUCH, CONST VALUE

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void Start()
    {
        // ConfigThirdPersonMousePointer();
        MoveToLastSavePoint();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        anim.SetBool("IsGrounded", is_grounded);
        if (pi.jump && is_grounded) Jump();
        AimCamera();
    }

    private void ConfigThirdPersonMousePointer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void MoveToLastSavePoint()
    {
        transform.position = SavePointManager.instance.GetLastSavePoint();
    }

    private void GetReferences()
    {
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void InitFields()
    {
        // move_speed = 30f;
        // jump_force = 150f;
        // vel_damp = 0.75f;
        is_grounded = false;
    }

    private void AimCamera()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cam_transform.eulerAngles.y, transform.eulerAngles.x);
    }

    /*private bool IsGrounded()
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.035f);
        Vector3 half_extents = new Vector3(0.125f, 0.0625f, 0.125f);
        Collider[] hits = Physics.OverlapBox(center, half_extents, Quaternion.identity, LayerMask.GetMask("Ground"));
        if (hits.Length > 0) return true;
        return false;
    }*/

    /*private void OnDrawGizmosSelected() // to test IsGrounded()
    {
        Gizmos.color = Color.green;
        Vector3 center = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.035f);
        Vector3 half_extents = new Vector3(0.125f, 0.0625f, 0.125f);
        Gizmos.matrix = Matrix4x4.TRS(center, Quaternion.identity, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, half_extents * 2);
    }*/

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
    }*/

    private void Move()
    {
        anim.SetFloat("Velocity", Mathf.Sign(pi.move_x) * new Vector2(pi.move_x, pi.move_z).normalized.magnitude);
        Vector3 move_dir = (transform.right * pi.move_x + transform.forward * pi.move_z).normalized;
        rb.linearVelocity += move_dir * move_speed * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * vel_damp, rb.linearVelocity.y, rb.linearVelocity.z * vel_damp);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jump_force);
    }

    public void Hurt()
    {
        // 양심적인 무적 시간^^
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
        // Unity 물리 엔진을 믿지 않는다...
        // 죽었으면 안 되지만, 다친 상태에서는 양심적으로 골대에 들어가게 해주자...
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Goal") || state.IsName("Die")) return;

        anim.SetTrigger("Goal");
    }
}