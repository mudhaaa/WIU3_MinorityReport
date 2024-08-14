using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Data", menuName = "Inventory Data", order = 1)]
public class InventoryData : ScriptableObject
{
    int countFoodItem = 0;

    public int CountFoodItem
    {
        get { return countFoodItem; }
        set { countFoodItem = value; }
    }

    private void OnEnable()
    {
        CountFoodItem = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
