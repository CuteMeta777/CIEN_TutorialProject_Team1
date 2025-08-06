using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab; // 인스펙터 창에서 prefab에 해당하는 변수에 스폰하고 싶은 오브젝트 연결할 것.
    public Transform spawnpoint;
    public float spawnInterval = 2f;//2초

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
