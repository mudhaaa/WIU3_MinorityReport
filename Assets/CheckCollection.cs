
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckCollection : MonoBehaviour
{
    public GameObject MainGame;
    public GameObject MiniGame;
    public BackgroundTransparencyAnim BlackBackground;
    public SpawnObjects spawnObjects;
    bool FinishGame = false;
    int Evidences = 0;
    int NonEvidences = 0;
    public LayerMask EvidenceLayer;
    public LayerMask NonEvidenceLayer;
    // Start is called before the first frame update
    void Update()
    {
        Evidences = 0;
        NonEvidences = 0;

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, transform.localScale, 0, Vector2.zero, Mathf.Infinity, EvidenceLayer);
        foreach (RaycastHit2D hit in hits)
        {
            GameObject hitObject = hit.collider.gameObject;
            Evidences++;
        }

        if (Evidences >= spawnObjects.MaxEvidencesSpawned || FinishGame)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                FinishGame = true;
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                FinishGame = false;
                MiniGame.SetActive(false);
                MainGame.SetActive(true);
            }
        }

    }
}