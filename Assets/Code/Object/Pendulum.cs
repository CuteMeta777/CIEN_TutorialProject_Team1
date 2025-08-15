using UnityEngine;

public class Pivot : MonoBehaviour
{
    public enum PivotMode { WorldPoint, LocalPoint }

    [Header("회전축 입력")]
    public PivotMode pivotMode = PivotMode.WorldPoint;

    [Tooltip("WolrdPoint 모드일 때 사용")]
    public Vector3 pivotWorld;

    [Tooltip("LocaPoint 모드일 때 사용(오브젝트 로컬 좌표)")]
    public Vector3 pivotLocal;

    [Header("회전 운동 설정")]
    public Vector3 axis = Vector3.forward;
    [Range(0f, 179f)] public float amplitude = 30f;
    public float frequency = 0.5f;
    [Range(-180f, 180f)] public float phase = 0f;
    [Min(0f)] public float damping = 0f;

    [Header("자세 제어")]
    public bool facePivot = true;

    float t0, lastAngle;
    Vector3 pivotWorldFixed;
    Vector3 lastValidForward;
    const float EPS = 1e-8f;

    void OnEnable()
    {
        t0 = Time.time;
        lastAngle = 0f;

        if ( pivotMode == PivotMode.WorldPoint) { pivotWorldFixed = pivotWorld; }
        else { pivotWorldFixed = transform.TransformPoint(pivotLocal); }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - t0;
        float ampNow = amplitude * Mathf.Exp(-damping * t);
        float angle = ampNow * Mathf.Sin(2f * Mathf.PI * frequency * t + phase * Mathf.Deg2Rad);
        float delta = angle - lastAngle;

        Vector3 ax = axis.sqrMagnitude > 0f ? axis.normalized : Vector3.forward;

        transform.RotateAround(pivotWorldFixed, ax, delta);

        if (facePivot) 
        {
            Vector3 dirToPivot = pivotWorldFixed - transform.position;
            if (dirToPivot.sqrMagnitude > EPS)
            {
                transform.rotation = Quaternion.LookRotation(dirToPivot, ax);
                lastValidForward = dirToPivot.normalized;
            }
            else
            {
                Vector3 safeFwd = lastValidForward;
                if (Mathf.Abs(Vector3.Dot(safeFwd, ax)) > 0.999f)
                {
                    Vector3 arbitrary = Mathf.Abs(ax.y) < 0.9f ? Vector3.up : Vector3.right;
                    safeFwd = Vector3.Cross(ax, arbitrary).normalized;
                    lastValidForward = safeFwd;
                }
                transform.rotation = Quaternion.LookRotation(safeFwd, ax);
            }
        }

        lastAngle = angle;
    }
}
