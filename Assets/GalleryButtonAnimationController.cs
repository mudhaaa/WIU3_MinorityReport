using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryButtonAnimationController : MonoBehaviour
{
    public int Index;
    public Animator animator;

    public string dialogPath;

    public DialogSystem dialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Normal"))
        {
            animator.Play("Null");
        }
        else if(animator.GetBool("Highlighted"))
        {
            animator.Play("GalleryButtonHighlighted");
        }
        else if (animator.GetBool("Pressed") || animator.GetBool("Selected"))
        {
            animator.Play("GalleryButtonPressed_" + Index);
        }
        else if(animator.GetBool("Disabled"))
        {
            animator.Play("GalleryButtonDisabled");
        }
    }

    void hideAllBesideSelf()
    {
        int numOfSiblings = transform.parent.childCount;
        for(int i = 1; i <numOfSiblings; ++i)
        {
            if(transform.parent.GetChild(i).gameObject != gameObject)
            {
                transform.parent.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void startDialog()
    {
        dialogSystem.FilePath = dialogPath;
        dialogSystem.StartNewDialogues();
        GalleryManager.IsReviewEnding = true;
    }
}
