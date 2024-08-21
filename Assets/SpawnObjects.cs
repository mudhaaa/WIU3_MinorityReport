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

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i < MaxEvidencesSpawned; i++)
        {
            if (WineBottlePrefab == null || Random.Range(0, 2) == 0)
            {
                Vector3 SpawnArea = Area.GetScale();
                Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
                GameObject temp = Instantiate(ReceiptPrefab, pos, Quaternion.identity, Parent);
                temp.GetComponent<DraggableObject2D>().pDialogSystem = pDialogSystem;
            }
            else
            {
                Vector3 SpawnArea = Area.GetScale();
                Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
                GameObject temp = Instantiate(WineBottlePrefab, pos, Quaternion.identity, Parent);
                temp.GetComponent<DraggableObject2D>().pDialogSystem = pDialogSystem;
            }
        }
        for (int i = 0; i < MaxNonEvidencesSpawned; i++)
        {
            Vector3 SpawnArea = Area.GetScale();
            Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
            GameObject temp = Instantiate(NonEvidencePrefab, pos, Quaternion.identity, Parent);
            temp.GetComponent<DraggableObject2D>().pDialogSystem = pDialogSystem;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
