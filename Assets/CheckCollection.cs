using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollection : MonoBehaviour
{
    int Evidences = 0;
    int NonEvidences = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Evidences = 0;
        NonEvidences = 0;

        RaycastHit2D[] collision = Physics2D.BoxCastAll(transform.position, transform.localScale, 0, Vector2.zero, LayerMask.NameToLayer("Evidence"));
    }
}
