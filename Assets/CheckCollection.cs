
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CheckCollection : MonoBehaviour
{
    public GameObject MainGame;
    public GameObject MiniGame;
    public GameObject InvetigationGUI;
    public TextMeshProUGUI investigationtext;
    public BackgroundTransparencyAnim BlackBackground;
    public SpawnObjects spawnObjects;
    public InventoryManager inventoryManager;

    public Item EvidenceReward;
    public Item NonEvidenceReward;
    bool FinishGame = false;
    int Evidences = 0;
    int NonEvidences = 0;
    public LayerMask EvidenceLayer;
    public LayerMask NonEvidenceLayer;
    // Start is called before the first frame update

    private void OnEnable()
    {
        InvetigationGUI.SetActive(true);
    }
    private void OnDisable()
    {
        InvetigationGUI.SetActive(false);
    }
    void Update()
    {
        if (!FinishGame)
        {
            Evidences = 0;
            NonEvidences = 0;

            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, transform.localScale, 0, Vector2.zero, Mathf.Infinity, EvidenceLayer);
            foreach (RaycastHit2D hit in hits)
            {
                GameObject hitObject = hit.collider.gameObject;
                Evidences++;
            }

            RaycastHit2D[] hits2 = Physics2D.BoxCastAll(transform.position, transform.localScale, 0, Vector2.zero, Mathf.Infinity, NonEvidenceLayer);
            foreach (RaycastHit2D hit in hits2)
            {
                GameObject hitObject = hit.collider.gameObject;
                NonEvidences++;
            }
            investigationtext.text = "Items Collected: " + (Evidences + NonEvidences) + " / " + ((spawnObjects.MaxEvidencesSpawned + spawnObjects.MaxNonEvidencesSpawned) / 2);
        }
        if ((Evidences + NonEvidences) >= ((spawnObjects.MaxEvidencesSpawned + spawnObjects.MaxNonEvidencesSpawned) / 2) || FinishGame)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                FinishGame = true;
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                inventoryManager.AddItem(EvidenceReward, Evidences);
                inventoryManager.AddItem(NonEvidenceReward, NonEvidences);
                FinishGame = false;
                MiniGame.SetActive(false);
                MainGame.SetActive(true);
            }
        }

    }
}