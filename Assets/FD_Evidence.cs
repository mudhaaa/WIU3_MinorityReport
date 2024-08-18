using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FD_Evidence : MonoBehaviour
{
    [Header("Physics 2D")]
    public Rigidbody2D rb;
    [SerializeField] FlashlightDarknessGame game;

    private Vector2 mousePosition = Vector2.zero;
    private void Start()
    {
        game = GameObject.FindObjectOfType<FlashlightDarknessGame>();
    }
    void Update()
    {
    }

    void OnMouseDown()
    {
        game.AmountFound++;
        Destroy(gameObject);
    }
}