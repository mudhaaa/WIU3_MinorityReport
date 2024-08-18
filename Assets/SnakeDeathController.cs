using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeDeathController : MonoBehaviour
{
    public SnakeController SnakeController;
    public DeleteObjectsOnDisable Food;
    public DeleteObjectsOnDisable SnakeBodies;
    float Timer;
    float MaxTimer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        SnakeController.gameObject.transform.localPosition = Vector3.zero;
        SnakeBodies.DeleteAllChildren();
        Food.DeleteAllChildren();
        Debug.Log("Spawning");
        Food.gameObject.GetComponent<FoodSpawning>().SpawnFood(new Vector3(3.0f, 0.0f, 0.0f));
    }
    // Update is called once per frame
    void Update()
    {
        if (SnakeController.enabled == false)
        {
            Timer += Time.deltaTime;
            if (Timer > MaxTimer)
            {
                Timer = 0.0f;
                SnakeController.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
    }
}
