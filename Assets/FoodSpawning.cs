using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodSpawning : MonoBehaviour
{
    [SerializeField] GameObject ObstaclePrefab;
    Vector3 SpawnPoint;
    [SerializeField] float DestroyTime = 5.0f;
    // Start is called before the first frame update
    void OnEnable()
    {
    }

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnFood()
    {
        Vector3 ScreenWorld = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0 , Screen.width ), Random.Range(0 , Screen.height ), 0));
        SpawnPoint = new Vector3(Mathf.FloorToInt(ScreenWorld.x), Mathf.FloorToInt(ScreenWorld.y), 0.0f);
        GameObject food = Instantiate(ObstaclePrefab, SpawnPoint, Quaternion.identity, transform);
        food.transform.localPosition = new Vector3(Mathf.MoveTowards(Mathf.FloorToInt(food.transform.localPosition.x), 0.0f, 2.0f), Mathf.MoveTowards(Mathf.FloorToInt(food.transform.localPosition.y), 0.0f, 2.0f), 0.0f);

    }
    public void SpawnFood(Vector3 position)
    {
        SpawnPoint = new Vector3(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0.0f);
        GameObject food = Instantiate(ObstaclePrefab, SpawnPoint + transform.position, Quaternion.identity, transform);
        food.transform.localPosition = new Vector3(Mathf.MoveTowards(Mathf.FloorToInt(food.transform.localPosition.x), 0.0f, 2.0f), Mathf.MoveTowards(Mathf.FloorToInt(food.transform.localPosition.y), 0.0f, 2.0f), 0.0f);
    }
}
