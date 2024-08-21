using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInteraction : ScriptableObject
{
    // Start is called before the first frame update
    public abstract bool Interact(GameObject Parent);
    public abstract void Init(Item Parent);
}
