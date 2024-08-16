using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public bool Hide;
    [SerializeField] public bool Died;

    private void Start()
    {
        Hide = false;
        Died = false;
    }
}
