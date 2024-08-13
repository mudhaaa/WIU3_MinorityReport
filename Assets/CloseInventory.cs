using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    // Start is called before the first frame update
    bool CoroutineRunning = false;
    [SerializeField] TranslateAnim EquipmentTranslateAnim;
    [SerializeField] TranslateAnim InventoryTranslateAnim;
    [SerializeField] BackgroundTransparencyAnim backgroundTransparencyAnim;
    [SerializeField] BackgroundTransparencyAnim SanityBar;
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
        CoroutineRunning = true;
        if (EquipmentTranslateAnim.CoroutineRunning)
        {
            EquipmentTranslateAnim.CoroutineRunning = false;
            StopCoroutine(EquipmentTranslateAnim.currentcoroutine);
        }
        EquipmentTranslateAnim.currentcoroutine = StartCoroutine(EquipmentTranslateAnim.Anim(new Vector2(EquipmentTranslateAnim.TargetPosition.x, -Screen.height), 0.01f));

        if (InventoryTranslateAnim.CoroutineRunning)
        {
            InventoryTranslateAnim.CoroutineRunning = false;
            StopCoroutine(InventoryTranslateAnim.currentcoroutine);
        }
        InventoryTranslateAnim.currentcoroutine = StartCoroutine(InventoryTranslateAnim.Anim(new Vector2(InventoryTranslateAnim.TargetPosition.x, -Screen.height), 0.01f));

        if (backgroundTransparencyAnim.CoroutineRunning)
        {
            backgroundTransparencyAnim.CoroutineRunning = false;
            StopCoroutine(backgroundTransparencyAnim.currentcoroutine);
        }
        backgroundTransparencyAnim.currentcoroutine = StartCoroutine(backgroundTransparencyAnim.Anim(0.0f, 0.01f));

        if (SanityBar.CoroutineRunning)
        {
            SanityBar.CoroutineRunning = false;
            StopCoroutine(SanityBar.currentcoroutine);
        }
        SanityBar.currentcoroutine = StartCoroutine(SanityBar.Anim(0.0f, 0.01f));

        while (CoroutineRunning)
        {
            if (EquipmentTranslateAnim.CoroutineRunning == false && InventoryTranslateAnim.CoroutineRunning == false && backgroundTransparencyAnim.CoroutineRunning == false && SanityBar.CoroutineRunning ==false)
            {
                CoroutineRunning = false;
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
        yield break;

    }
    public void Close()
    {
        if (currentcoroutine != null)
        {
            CoroutineRunning = false;
            StopCoroutine(currentcoroutine);
        }
        currentcoroutine = StartCoroutine(OnClose());
    }
    public void Open()
    {
        if (currentcoroutine != null)
        {
            CoroutineRunning = false;
            //StopCoroutine(currentcoroutine);
        }

        if (EquipmentTranslateAnim.CoroutineRunning)
        {
            EquipmentTranslateAnim.CoroutineRunning = false;
            StopCoroutine(EquipmentTranslateAnim.currentcoroutine);
        }
        EquipmentTranslateAnim.currentcoroutine = StartCoroutine(EquipmentTranslateAnim.Anim(EquipmentTranslateAnim.TargetPosition, 0.01f));
        if (InventoryTranslateAnim.CoroutineRunning)
        {
            InventoryTranslateAnim.CoroutineRunning = false;
            StopCoroutine(InventoryTranslateAnim.currentcoroutine);
        }
        InventoryTranslateAnim.currentcoroutine = StartCoroutine(InventoryTranslateAnim.Anim(InventoryTranslateAnim.TargetPosition, 0.01f));

        if (backgroundTransparencyAnim.CoroutineRunning)
        {
            backgroundTransparencyAnim.CoroutineRunning = false;
            StopCoroutine(backgroundTransparencyAnim.currentcoroutine);
        }
        backgroundTransparencyAnim.currentcoroutine = StartCoroutine(backgroundTransparencyAnim.Anim(backgroundTransparencyAnim.TransparencyMax, 0.01f));

        if (SanityBar.CoroutineRunning)
        {
            SanityBar.CoroutineRunning = false;
            StopCoroutine(SanityBar.currentcoroutine);
        }
        SanityBar.currentcoroutine = StartCoroutine(SanityBar.Anim(1.0f, 0.01f));
    }
}
