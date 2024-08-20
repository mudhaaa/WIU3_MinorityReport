using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMirror : MonoBehaviour
{
    public bool FinishGame = false;
    public GameObject MainGame;
    public GameObject MiniGame;
    public BackgroundTransparencyAnim BlackBackground;
    public List<GameObject> objectsToRandomize; // List of GameObjects to randomize
    public GameObject ParticleSystem;

    private void Start()
    {
        RandomizeObjects();
        ParticleSystem.SetActive(false);
    }

    private void RandomizeObjects()
    {
        foreach (GameObject obj in objectsToRandomize)
        {
            // Add a random value to the x position
            float randomX = Random.Range(-1.2f, 1.2f);
            obj.transform.position = new Vector3(obj.transform.position.x + randomX, obj.transform.position.y, obj.transform.position.z);

            // Add a random value to the y position
            float randomY = Random.Range(-1.623f, 1.542f);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + randomY, obj.transform.position.z);

            // Randomize scale
            float randomScale = Random.Range(0.07f, 0.16f);
            obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePosition);

            if (hit != null)
            {
                if (hit.gameObject.layer == LayerMask.NameToLayer("Dust"))
                {
                    hit.gameObject.SetActive(false);
                }
            }
        }

        bool allClothesInactive = true;
        foreach (GameObject dust in objectsToRandomize)
        {
            if (dust.activeInHierarchy)
            {
                allClothesInactive = false;
                break;
            }
        }

        if (allClothesInactive)
        {
            FinishGame = true;
        }

        if (FinishGame)
        {
            ParticleSystem.SetActive(true);
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