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
    public GameObject EvidencePrefab;
    public GameObject NonEvidencePrefab;

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i < MaxEvidencesSpawned; i++)
        {
            Vector3 SpawnArea = Area.GetScale();
            Vector3 pos = new Vector3(Random.Range(-SpawnArea.x, SpawnArea.x), Random.Range(-SpawnArea.y, SpawnArea.y), 0) + transform.position;
            GameObject temp = Instantiate(EvidencePrefab, pos, Quaternion.identity, Parent);

            if (temp.GetComponent<DraggableObject2D>() != null)
            {
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
