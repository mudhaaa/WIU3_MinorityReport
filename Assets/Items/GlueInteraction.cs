using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Scriptable object/Glue Interaction")]
public class GlueInteraction : ItemInteraction
{
    [SerializeField] string Text = "Glue";
    [SerializeField] private GameObject gluePrefab;
    Item ItemParentedTo;
    public override bool Interact(GameObject Parent)
    {
        GameObject specialObject = Instantiate(gluePrefab, Parent.transform.position, Quaternion.identity);
        return true;
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
