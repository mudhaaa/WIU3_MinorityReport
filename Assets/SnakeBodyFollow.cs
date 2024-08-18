using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;

    void Start()
    {
        
    }

    // Update is called once per frame

    public void BodyFollow(int index)
    {
        
        if (transform.childCount - 1 >= index)
        {
            BodyFollow(index + 1);
            Transform child = transform.GetChild(index);
            if (index == 0)
            {
                child.position = Head.transform.position;
            }
            else
            {
                Transform PrevChild = transform.GetChild(index-1);
                child.position = PrevChild.position;
            }
        }
    }
}
