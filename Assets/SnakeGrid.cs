using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnakeGrid : MonoBehaviour
{
    public GameObject SizeBasedOn;
    public Vector2 GridAmtUnitSize;
    public Vector2 GridUnitSize;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GridAmtUnitSize = SizeBasedOn.transform.localScale / GridUnitSize;
        GridAmtUnitSize.x = Mathf.FloorToInt(GridAmtUnitSize.x);
        GridAmtUnitSize.y = Mathf.FloorToInt(GridAmtUnitSize.y);
        Debug.Log(GridAmtUnitSize);
    }


}
