using UnityEngine;

// 시간차를 두고 사라지는 것. (주로 내려찍은 뒤에 튕겨나온 오브젝트를 정리하기 위해 사용?)
public class TimelyDespawn : TriggeredTrap
{
    [SerializeField] private float despawn_time;

    public override void React()
    {
        Die(despawn_time);
    }

    private void Die(float despawn_time)
    {
        // add particle effect later
        Destroy(gameObject, despawn_time);
    }
}