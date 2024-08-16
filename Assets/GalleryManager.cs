using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Button[] EndingButtons;
    public Text[] EndingLabels;

    public static bool IsReviewEnding;
    public DialogSystem dialogSystem;

    // Start is called before the first frame update
    void Start()
    { 
        for(int i = 0; i < 5; ++i)
        {
            EndingButtons[i].interactable = GameManager.Instance.IsEndingCompleted[i];
            if (GameManager.Instance.IsEndingCompleted[i] == false)
            {
                EndingLabels[i].text = "???";
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(IsReviewEnding == true && 
            dialogSystem.IsCompleted() == true)
        {
            int childCount = transform.childCount;
            for(int i = 0; i < childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            IsReviewEnding = false;
        }
    }

    public static void test()
    {
        Debug.Log("asd");
    }
}
