using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Scriptable object/Sanity Interaction")]
public class SanityInteraction : ItemInteraction
{
    Item ItemParentedTo;
    public override bool Interact(GameObject Parent)
    {
        Sanity sanityfromparent = Parent.GetComponent<Sanity>();
        if (sanityfromparent != null)
        {
            if (sanityfromparent.ISanity < sanityfromparent.maxsanity)
            {
                sanityfromparent.ISanity += ItemParentedTo.SanityRegen;
                return true;
            }
        }
        return false;
    }

    public override void Init(Item Parent)
    {
        ItemParentedTo = Parent;
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
