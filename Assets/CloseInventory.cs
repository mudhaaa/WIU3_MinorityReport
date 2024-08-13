using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TranslateAnim EquipmentTranslateAnim;
    [SerializeField] TranslateAnim InventoryTranslateAnim;
    [SerializeField] BackgroundTransparencyAnim backgroundTransparencyAnim;
    Coroutine currentcoroutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OnClose()
    {
        if (EquipmentTranslateAnim.currentcoroutine != null)
        {
            EquipmentTranslateAnim.CoroutineRunning = false;
            StopCoroutine(EquipmentTranslateAnim.currentcoroutine);
        }
        EquipmentTranslateAnim.currentcoroutine = StartCoroutine(EquipmentTranslateAnim.Anim(new Vector2(EquipmentTranslateAnim.TargetPosition.x, -Screen.height), 0.01f));

        if (InventoryTranslateAnim.currentcoroutine != null)
        {
            InventoryTranslateAnim.CoroutineRunning = false;
            StopCoroutine(InventoryTranslateAnim.currentcoroutine);
        }
        InventoryTranslateAnim.currentcoroutine = StartCoroutine(InventoryTranslateAnim.Anim(new Vector2(InventoryTranslateAnim.TargetPosition.x, -Screen.height), 0.01f));

        if (backgroundTransparencyAnim.currentcoroutine != null)
        {
            backgroundTransparencyAnim.CoroutineRunning = false;
            StopCoroutine(backgroundTransparencyAnim.currentcoroutine);
        }
        backgroundTransparencyAnim.currentcoroutine = StartCoroutine(backgroundTransparencyAnim.Anim(0.0f, 0.01f));

        while (true)
        {
            if (EquipmentTranslateAnim.CoroutineRunning == false && InventoryTranslateAnim.CoroutineRunning == false && backgroundTransparencyAnim.CoroutineRunning == false)
            {
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
    public void Close()
    {
        if (currentcoroutine != null)
        {
            StopCoroutine(currentcoroutine);
        }
        StartCoroutine(OnClose());
    }
    public void Open()
    {
        if (EquipmentTranslateAnim.currentcoroutine != null)
        {
            EquipmentTranslateAnim.CoroutineRunning = false;
            StopCoroutine(EquipmentTranslateAnim.currentcoroutine);
        }
        EquipmentTranslateAnim.currentcoroutine = StartCoroutine(EquipmentTranslateAnim.Anim(EquipmentTranslateAnim.TargetPosition, 0.01f));
        if (InventoryTranslateAnim.currentcoroutine != null)
        {
            InventoryTranslateAnim.CoroutineRunning = false;
            StopCoroutine(InventoryTranslateAnim.currentcoroutine);
        }
        InventoryTranslateAnim.currentcoroutine = StartCoroutine(InventoryTranslateAnim.Anim(InventoryTranslateAnim.TargetPosition, 0.01f));

        if (backgroundTransparencyAnim.currentcoroutine != null)
        {
            backgroundTransparencyAnim.CoroutineRunning = false;
            StopCoroutine(backgroundTransparencyAnim.currentcoroutine);
        }
        backgroundTransparencyAnim.currentcoroutine = StartCoroutine(backgroundTransparencyAnim.Anim(backgroundTransparencyAnim.TransparencyMax, 0.01f));
    }
}
