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
            SanityScript.ISanity = Mathf.Clamp(SanityScript.ISanity + inventoryitem.ITEM.SanityRegen, 0, SanityScript.maxsanity);
            inventoryitem.count -= 1;
            inventoryitem.RefreshCount();
        }
    }
}
