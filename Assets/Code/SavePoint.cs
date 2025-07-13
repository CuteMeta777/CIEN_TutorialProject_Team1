using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(45, 45, 45); // ���߿� ���(?)���� �ɷ� Animation�� ������ ������, �ϴ��� �۵��Ǵ����� �׽�Ʈ�غ��� ����.
            SavePointManager.instance.SetLastSavePoint(transform.position);
        }
    }
}