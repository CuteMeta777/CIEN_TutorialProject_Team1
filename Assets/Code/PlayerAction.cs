using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerInput pi;
    private Rigidbody rb;
    private Animator anim;

    private float move_speed;
    private float jump_force;
    private float vel_damp;
    private bool is_grounded;

    [SerializeField] private Transform cam_transform;

    private void Awake()
    {
        GetReferences();
        InitFields();
    }

    private void GetReferences()
    {
        pi = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void InitFields()
    {
        move_speed = 500f;
        jump_force = 750f;
        vel_damp = 0.75f;
        is_grounded = false;
    }

    private void Start()
    {
        ConfigMousePointer("Third Person");
    }

    private void ConfigMousePointer(string value) // value는 필요 없음. Third Person Setting이라는 것을 알려줄 뿐.
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Move();
        // if (pi.jump) Jump();
    }

    private void Update()
    {
        is_grounded = IsGrounded();
        anim.SetBool("IsGrounded", is_grounded);
        if (pi.jump && is_grounded) Jump();
        AimCamera();
    }

    private void AimCamera()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cam_transform.eulerAngles.y, transform.eulerAngles.x);
    }

    private bool IsGrounded()
    {
        Collider[] hits = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, LayerMask.GetMask("Ground"));
        if (hits.Length > 0) return true;
        return false;
    }

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

    public void OnLand()
    {
        // play sound
    }
}