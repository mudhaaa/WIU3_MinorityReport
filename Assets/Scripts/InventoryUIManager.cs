using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TMPro.TMP_Text textFoodItemCount;
    [SerializeField]
    InventoryData inventoryData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryData != null)
        {
            textFoodItemCount.text = "x " + inventoryData.CountFoodItem;
        }
    }
}
