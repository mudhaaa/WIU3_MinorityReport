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

    [Header("Only UI")]
    public bool Stackable = true;

    [Header("Both")]
    public Sprite image;

    // Add a cloning method
    public Item Clone()
    {
        return (Item)this.MemberwiseClone();
    }
}

public enum ItemType
{
    SanityItem,
    Evidence
}


//public enum ActionType
//{
//    Dig,
//    Mine
//}
