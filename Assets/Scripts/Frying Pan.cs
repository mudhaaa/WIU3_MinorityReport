using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FryingPan : MonoBehaviour
{

    // List of object names that should be inside the circle collider
    [SerializeField] public List<GameObject> FoodObjects;
    [SerializeField] public List<GameObject> RecipeObjects;
    [SerializeField] public List<string> requiredObjects1;
    [SerializeField] public List<string> requiredObjects2;
    [SerializeField] public List<string> requiredObjects3;
    [SerializeField] public List<string> requiredObjects4;
    [SerializeField] public List<string> requiredObjects;

    [SerializeField] public KitchenGame KitchenGame;
    [SerializeField] public int FoodToMake;
    [SerializeField] public TextMeshProUGUI RecipeInfo;
    // A HashSet to keep track of the objects currently in the circle collider
    private HashSet<string> objectsInCollider = new HashSet<string>();


    private void Update()
    {
        if (KitchenGame.FoodToMake == KitchenGame.Foods.Burger)
        {
            requiredObjects = requiredObjects1;
        }
        else if (KitchenGame.FoodToMake == KitchenGame.Foods.Steak)
        {
            requiredObjects = requiredObjects2;
        }
        else if (KitchenGame.FoodToMake == KitchenGame.Foods.Salmon)
        {
            requiredObjects = requiredObjects3;
        }
        else if (KitchenGame.FoodToMake == KitchenGame.Foods.RoastedChicken)
        {
            requiredObjects = requiredObjects4;
        }
        RecipeInfo.SetText("What to make:" + KitchenGame.FoodToMake + " Ingredients Required:" + requiredObjects.Count);
        CheckAllObjectsInCollider();
    }
    // Trigger detection
    void OnTriggerEnter2D(Collider2D other)
    {
        objectsInCollider.Add(other.gameObject.name);
        Debug.Log(other.gameObject.name + " entered the circle collider.");


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (objectsInCollider.Contains(other.gameObject.name))
        {
            objectsInCollider.Remove(other.gameObject.name);
            Debug.Log(other.gameObject.name + " exited the circle collider.");
        }
    }

    // Check if all required objects are inside the collider
    void CheckAllObjectsInCollider()
    {
        bool allObjectsPresent = true;
        bool onlyRequiredObjects = true;

        foreach (string requiredObject in requiredObjects)
        {
            if (!objectsInCollider.Contains(requiredObject))
            {
                allObjectsPresent = false;
                break;
            }
        }

        foreach (string objectInCollider in objectsInCollider)
        {
            if (!requiredObjects.Contains(objectInCollider))
            {
                onlyRequiredObjects = false;
                break;
            }
        }

        if (allObjectsPresent && onlyRequiredObjects)
        {
            foreach (GameObject obj in FoodObjects)
            {
                obj.SetActive(false);
            }
            RecipeObjects[FoodToMake].SetActive(true);
            KitchenGame.FinishGame = true;
            gameObject.SetActive(false);
        }
    }
}