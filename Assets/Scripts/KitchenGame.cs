using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public enum Foods
    {
        Burger = 0,
        Steak,
        Salmon,
        RoastedChicken,
        NumOfFoods
    }
    public static string[] FoodNames = new string[] {"Burger", "Steak", "Salmon", "RoastedChicken"};

    public bool FinishGame = false;
    public GameObject MainGame;
    public GameObject MiniGame;
    public BackgroundTransparencyAnim BlackBackground;
    // The layer that can be picked up
    public LayerMask pickableLayer;

    // The object being dragged
    private GameObject draggedObject;

    public GameObject[] objectsToDeactivate;
    [SerializeField] public Foods FoodToMake;

    public DialogSystem pDialogSystem;
    public TimeSystem timeSystem;
    public FinishMiniGame FinishMiniGame;

    public GameObject[] Ingredients;
    private Vector3[] IngredientDefaultPositions;

    public GameObject FryingPan;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate the objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    private void OnEnable()
    {
        timeSystem.pOnDayEnd += OnDayEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, pickableLayer);

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position


            // Check if the ray hits something with the pickable layer
            if (hit.collider != null)
            {
                // Get the hit object
                GameObject hitObject = hit.collider.gameObject;

                // Check if the object has a Rigidbody2D component
                if (hitObject.GetComponent<Rigidbody2D>() != null)
                {
                    // Set the dragged object
                    draggedObject = hitObject;

                    // Make the object kinematic to prevent physics from interfering with the drag
                    hitObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
     

            // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            // Get the mouse position in world space
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Move the dragged object to the mouse position
            draggedObject.transform.position = mousePosition;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            // Make the object non-kinematic again
            draggedObject.GetComponent<Rigidbody2D>().isKinematic = false;

            // Reset the dragged object
            draggedObject = null;
        }

        if (FinishGame)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                FinishGame = true;
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                FinishGame = false;
                MiniGame.SetActive(false);
                MainGame.SetActive(true);
                FinishMiniGame.FinishedGame = true;
            }
        }
    }

    public void OnDisable()
    {
        timeSystem.pOnDayEnd -= OnDayEnd;
    }

    public void OnDayStart()
    {
        if(timeSystem.Day == 0)
        {
            IngredientDefaultPositions = new Vector3[Ingredients.Length];
            for (int i = 0; i < Ingredients.Length; ++i)
            {
                IngredientDefaultPositions[i] = Ingredients[i].transform.localPosition;
            }
        }

        // activate the objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        for(int i = 0; i < Ingredients.Length; ++i)
        {
            Ingredients[i].SetActive(true);
            Ingredients[i].transform.localPosition = IngredientDefaultPositions[i];
        }

        if (timeSystem.Day < (int)Foods.NumOfFoods)
        {
            FoodToMake = (Foods)timeSystem.Day;
        }

        FryingPan.SetActive(true);
    }
 
    public void OnDayEnd()
    {
        MiniGame.SetActive(false);
        MainGame.SetActive(true);
    }

}