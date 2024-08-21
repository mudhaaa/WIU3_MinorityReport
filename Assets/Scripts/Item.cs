using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {


    [Header("Only gameplay")]
    public ItemType type;
    //public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    public float SanityRegen = 0.0f;

    public ItemInteraction ItemInteractScript;

    [Header("Only UI")]
    public bool Stackable = true;

    [Header("Both")]
    public Sprite image;

    // Add a cloning method
    public Item Clone()
    {
        // Create a shallow copy of the Item
        Item clone = (Item)this.MemberwiseClone();
        // If you want to create a deep copy of the ItemInteractScript
        if (ItemInteractScript != null)
        {
            clone.ItemInteractScript = Instantiate(ItemInteractScript);
        }

        return clone;
    }
}

public enum ItemType
{
    SanityItem,
    Evidence,
    SelfDefense
}


//public enum ActionType
//{
//    Dig,
//    Mine
//}
