using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab; // �ν����� â���� prefab�� �ش��ϴ� ������ �����ϰ� ���� ������Ʈ ������ ��.
    public Transform spawnpoint;
    public float spawnInterval = 2f;//2��

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            GameObject clone = Instantiate(prefab, spawnpoint.position, Quaternion.identity);
            timer = 0f;
            Destroy(clone, 3f);
        }
    }
}
