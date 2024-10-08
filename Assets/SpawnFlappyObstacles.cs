using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnFlappyObstacles : MonoBehaviour
{
    [SerializeField] GameObject ObstaclePrefab;
    float EdgeX = 0.0f;
    Vector3 SpawnPoint;
    float SpawnTimer = 0;
    float MaxSpawnTimer = 2;

    [SerializeField] float Max = 2;
    [SerializeField] float Min = 0.5f;
    [SerializeField] float DestroyTime = 5.0f;

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        SpawnTimer += Time.deltaTime;
        if (SpawnTimer >= MaxSpawnTimer)
        {
            SpawnObstacle();
            SpawnTimer = 0;
            MaxSpawnTimer = Random.Range(Min,Max);
        }
    }

    void SpawnObstacle()
    {
        Vector3 ScreenWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.1f, Random.Range(0, Screen.height), 0));
        SpawnPoint = new Vector3(ScreenWorld.x, Mathf.MoveTowards(ScreenWorld.y, 3.0f, 4.0f), 0.0f);
        Debug.Log(SpawnPoint.y);
        GameObject obstacle = Instantiate(ObstaclePrefab, SpawnPoint, Quaternion.identity, transform);
        obstacle.GetComponent<BirdFlappyObstacle>().pDialogSystem = pDialogSystem;
        Destroy(obstacle, DestroyTime);
    }
}   
