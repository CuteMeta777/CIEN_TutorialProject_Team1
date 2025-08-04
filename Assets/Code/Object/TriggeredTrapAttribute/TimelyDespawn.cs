using UnityEngine;

// �ð����� �ΰ� ������� ��. (�ַ� �������� �ڿ� ƨ�ܳ��� ������Ʈ�� �����ϱ� ���� ���?)
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