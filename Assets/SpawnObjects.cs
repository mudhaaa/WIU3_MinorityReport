using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] MiniGameArea Area;
    [SerializeField] float SpawnSizeMultiplier = 0.3f;
    public int MaxEvidencesSpawned = 5;
    public int MaxNonEvidencesSpawned = 5;
    [SerializeField] Transform Parent;
    public GameObject ReceiptPrefab;
    public GameObject WineBottlePrefab;
    public GameObject NonEvidencePrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i < MaxEvidencesSpawned; i++)
        {
            if (WineBottlePrefab == null || Random.Range(0, 2) == 0)
            {
                Vector3 SpawnArea = Area.GetScale();
                Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
                Instantiate(ReceiptPrefab, pos, Quaternion.identity, Parent);
            }
            else
            {
                Vector3 SpawnArea = Area.GetScale();
                Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
                Instantiate(WineBottlePrefab, pos, Quaternion.identity, Parent);
            }
        }
        for (int i = 0; i < MaxNonEvidencesSpawned; i++)
        {
            Vector3 SpawnArea = Area.GetScale();
            Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
            Instantiate(NonEvidencePrefab, pos, Quaternion.identity, Parent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
