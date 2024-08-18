using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Selection : MonoBehaviour
{
    bool EndArcade = false;
    int childsel = 0;
    GameObject SelectedChild;
    GameObject SelectedGame;
    public Volume CameraEffects;
    public VolumeProfile NewProf;
    public VolumeProfile NormalProf;
    public GameObject MainGame;
    public GameObject ArcadeUI;
    public BackgroundTransparencyAnim BlackBackground;

    int ChildSelection {  
        get { return childsel; }
        set {
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
        CameraEffects.profile = NewProf;
        EndArcade = false;
        ChildSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndArcade)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                CameraEffects.profile = NormalProf;
                SelectedGame.SetActive(true);
                ArcadeUI.SetActive(false);
            }
        }
        else
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
                if (SelectedGame != MainGame)
                {
                    SelectedGame.SetActive(true);
                    ArcadeUI.SetActive(false);
                }
                else
                {
                    EndArcade = true;
                }
            }
        }
    }
}
