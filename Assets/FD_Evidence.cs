using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FD_Evidence : MonoBehaviour
{
    [Header("Physics 2D")]
    public Rigidbody2D rb;
    [SerializeField] FlashlightDarknessGame game;
    [SerializeField] AudioSource SoundWhenClicked;
    [SerializeField] float DestroyWaitTime = 2.0f;
    bool HitOnce = false;

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
        if (!HitOnce)
        {
            HitOnce = true;
            if (SoundWhenClicked != null)
            {
                SoundWhenClicked.Play();
            }
            if (game != null)
            {
                game.ReceiptAmountFound++;
                Destroy(gameObject, DestroyWaitTime);
            }
        }
    }
}