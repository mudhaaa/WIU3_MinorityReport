using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class PlayerHotbar : MonoBehaviour
{
    int childsel = 0;
    GameObject SelectedChild;
    InventoryItem SelectedItem;
    Color PrevColor;
    int ChildPrevChildCount = 0;
    public GameObject EquipmentSlots;
    public TimeSystem TimeSystem;
    int ChildSelection
    {
        get { return childsel; }
        set
        {
            EquipmentSlots.transform.GetChild(childsel).gameObject.GetComponent<Image>().color = PrevColor;
            childsel = value;
            if (childsel >= EquipmentSlots.transform.childCount)
            {
                childsel = EquipmentSlots.transform.childCount - 1;
            }
            else if (childsel < 0)
            {
                childsel = 0;
            }
            PrevColor = EquipmentSlots.transform.GetChild(childsel).gameObject.GetComponent<Image>().color;
            EquipmentSlots.transform.GetChild(childsel).gameObject.GetComponent<Image>().color = Color.grey;
            SelectedChild = EquipmentSlots.transform.GetChild(childsel).gameObject;

            SelectedItem = null;
            if (SelectedChild.transform.childCount > 0)
            {
                SelectedItem = SelectedChild.transform.GetChild(0).GetComponent<InventoryItem>();
            }
        }
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        PrevColor = EquipmentSlots.transform.GetChild(childsel).gameObject.GetComponent<Image>().color;
        ChildSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedChild.transform.childCount != ChildPrevChildCount)
        {
            SelectedItem = null;
            if (SelectedChild.transform.childCount > 0)
            {
                SelectedItem = SelectedChild.transform.GetChild(0).GetComponent<InventoryItem>();
            }
        }


        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyUp(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                ChildSelection = i - 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            if (SelectedItem != null)
            {
                if (SelectedItem.ITEM.ItemInteractScript != null)
                {
                    if (SelectedItem.ITEM.type == ItemType.SanityItem || TimeSystem.Day >= 5)
                    {
                        if (SelectedItem.ITEM.ItemInteractScript.Interact(this.gameObject))
                        {
                            SelectedItem.count--;
                            SelectedItem.RefreshCount();
                        }
                    }
                }
            }
        }
        ChildPrevChildCount = SelectedChild.transform.childCount;
    }
}
