using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public AudioSource src;
    public PlayerMainController maincharacterController;
    public Sanity SanityScript;
    // Update is called once per frame
    void Update()
    {
        InventoryItem inventoryitem = this.GetComponentInChildren<InventoryItem>();
        if (inventoryitem != null && SanityScript.ISanity < SanityScript.maxsanity)
        {
            src.Play();
            SanityScript.ISanity = Mathf.Clamp(SanityScript.ISanity + inventoryitem.ITEM.Healing, 0, SanityScript.maxsanity);
            if (inventoryitem.count <= 1)
            {
                Destroy(inventoryitem.gameObject);
            }
            else
            {
                inventoryitem.count -= 1;
            }
        }
    }
}
