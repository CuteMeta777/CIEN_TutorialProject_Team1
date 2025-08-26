using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private enum Type
    {
        InstaKill,
        Knockback
    }
    [SerializeField] private Type type;
    [SerializeField, Tooltip("Type이 Knockback인 경우에만 사용됨~")] private float knockback_force;

    // Obstacle이 Trigger인 경우 (주로 영역)
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player가 PlayerAction 컴포넌트를 지니고 있지 않습니다!"); return; }

        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        //if (type == Type.Knockback)
        //{
        //    pa.Knockback();
        //    return;
        //}

        Debug.Log("잘못된 Type을 지닌 Obstacle이 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
    }

    // Obstacle이 Rigid-Body Object인 경우 (주로 닿으면 죽는 나무 판자와 같은 것?)
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerAction pa = other.gameObject.GetComponent<PlayerAction>();
        if (pa == null) { Debug.Log("Player가 PlayerAction 컴포넌트를 지니고 있지 않습니다!"); return; }

        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        if (type == Type.Knockback)
        {
            pa.Knockback();
            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<PlayerAction>().rb.AddForce(knockbackDirection * knockback_force, ForceMode.Impulse);
            return;
        }

        Debug.Log("잘못된 Type을 지닌 Obstacle이 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
    }
}