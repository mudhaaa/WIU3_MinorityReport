using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public SnakeGrid snakeGrid;
    public GameObject snakebodies;
    public GameObject SnakeBodyPrefab;
    public FoodSpawning foodspawning;
    SnakeBodyFollow snakebodyscript;
    public BirdFlappyGameManager birdFlappyGameManager;
    float LastHorDir;
    float LastVerDir;
    Vector2 Direction = Vector2.zero;
    float SnakeMoveTimer = 0;
    [SerializeField] float MaxSnakeMoveTimer = 0.25f;
    [SerializeField] AudioSource MoveSFX;
    [SerializeField] AudioSource GameOverSFX;
    // Start is called before the first frame update
    private void Start()
    {
        snakebodyscript = snakebodies.GetComponent<SnakeBodyFollow>();
    }

    private void OnEnable()
    {
        LastHorDir = 0; LastVerDir = 0;
        Direction = Vector2.zero;
    }
    void Update()
    {
        float HorDir = Input.GetAxisRaw("Horizontal");
        float VerDir = Input.GetAxisRaw("Vertical");
        if (HorDir != 0 && HorDir != -Direction.x)
        {
            LastHorDir = HorDir;
            LastVerDir = 0;
        }
        else if (VerDir != 0 && VerDir != -Direction.y)
        {
            LastVerDir = VerDir;
            LastHorDir = 0;
        }

        Direction.x = LastHorDir;
        Direction.y = LastVerDir;
        SnakeMoveTimer += Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SnakeMoveTimer > MaxSnakeMoveTimer)
        {
            if (Mathf.Abs(LastHorDir) > 0 || Mathf.Abs(LastVerDir) > 0)
            {
                MoveSFX.Play();
            }
            snakebodyscript.BodyFollow(0);
            transform.position = transform.position + new Vector3(snakeGrid.GridUnitSize.x * LastHorDir, snakeGrid.GridUnitSize.y * LastVerDir, 0);
            SnakeMoveTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            birdFlappyGameManager.FlappyCount++;
            Destroy(collision.gameObject);
            GameObject SnakeBody = Instantiate(SnakeBodyPrefab, snakebodies.transform);
            SnakeBody.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 2, Screen.height * 2, 0));
            foodspawning.SpawnFood();
        }
        else if (this.enabled)
        {


            this.enabled = false;
            GameOverSFX.Play();

        }
    }
}
