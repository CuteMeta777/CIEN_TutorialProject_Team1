using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(45, 45, 45); // 나중엔 깃발(?)같은 걸로 Animation을 적용할 거지만, 일단은 작동되는지만 테스트해보기 위함.
            SavePointManager.instance.SetLastSavePoint(transform.position);
        }
    }
}