using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // 아직 밀려나는 건 구현되지 않음...

    private enum Type
    {
        InstaKill,
        Knockback
    }
    [SerializeField] private Type type;

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