using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class ArcadeSelection : MonoBehaviour
{
    bool EndArcade = false;
    int childsel = 0;
    GameObject SelectedChild;
    GameObject SelectedGame;
    public GameObject MainArcadeUI;
    public GameObject ArcadeUI;
    public GameObject CurrentGame;

    int ChildSelection
    {
        get { return childsel; }
        set
        {
            transform.GetChild(childsel).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            childsel = value;
            if (childsel >= transform.childCount)
            {
                childsel = 0;
            }
            else if (childsel < 0)
            {
                childsel = transform.childCount - 1;
            }

            transform.GetChild(childsel).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            SelectedChild = transform.GetChild(childsel).gameObject;
            SelectedGame = SelectedChild.GetComponent<ArcadeGame>().MiniGame;
        }
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        EndArcade = false;
        ChildSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ChildSelection--;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ChildSelection++;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (SelectedGame == MainArcadeUI)
            {
                CurrentGame.SetActive(false);
            }
            SelectedGame.SetActive(true);
            ArcadeUI.SetActive(false);
        }

    }
}
