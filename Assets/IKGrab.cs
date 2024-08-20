using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKGrab : MonoBehaviour
{
    IKSolver2D IKArm;
    [SerializeField] DraggableObject2D Draggable;
    // Start is called before the first frame update
    void Start()
    {
        IKArm = GameObject.FindObjectOfType<IKSolver2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Draggable.isDragging)
        {
            if (IKArm.gameObject.activeSelf)
            {
                IKArm.Target = transform.position;
            }
        }
    }
}
