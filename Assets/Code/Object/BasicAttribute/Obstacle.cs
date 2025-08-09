using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private enum Type
    {
        InstaKill
    }
    [SerializeField] private Type type;

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

        Debug.Log("잘못된 Type을 지닌 Obstacle이 존재합니다! (ID : " + gameObject.GetInstanceID() + ")");
    }
}