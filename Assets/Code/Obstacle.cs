using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // 아직 밀려나는 건 구현되지 않음... 근데 밀려나서 떨어지도록 하는 건 이걸 통해서 구현하는 것보다는 그냥 Rigidbody로 하는 게 나을지도?

    private enum Type
    {
        InstaKill,
        Knockback
    }
    [SerializeField] private Type type;

    // Obstacle이 Trigger인 경우 (주로 영역)
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        if (type == Type.Knockback)
        {
            pa.Hurt();
            return;
        }

        Debug.Log("잘못된 Type을 지닌 Obstacle이 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
    }

    // Obstacle이 Rigid-Body Object인 경우 (주로 닿으면 죽는 나무 판자와 같은 것?)
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerAction pa = FindFirstObjectByType<PlayerAction>();
        if (type == Type.InstaKill)
        {
            pa.Die();
            return;
        }
        if (type == Type.Knockback)
        {
            pa.Hurt();
            return;
        }

        Debug.Log("잘못된 Type을 지닌 Obstacle이 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
    }
}