using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitIntheShape : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] public MakeTheBed makeTheBed;
    [SerializeField] public LayerMask layer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layer) != 0)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.SetActive(false);
                spriteRenderer.color = Color.white;
                makeTheBed.PiecesPlaced += 1;
            }
        }
    }
}