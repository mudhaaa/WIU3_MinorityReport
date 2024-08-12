using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Text Content;
    public Text Name;

    public Image LeftImage;
    public Image MiddleImage;
    public Image RightImage;

    public string FilePath;
    public string[] Dialogues;
    public int LineIndex;

    public string NameToDisplay;
    public string DialogToDisplay;
    public int CharacterIndex;

    public bool IsLineCompleted;
    public bool IsCompleted;

    public static readonly float[] DisplayCoolDowns = new float[5]{ 0.05f, 0.1f, 0.2f, 0.4f, 0.6f }; 
    public float DisplayCountDown;

    private void Start()
    {
        //GetNewDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = NameToDisplay;

        if (!IsLineCompleted)
        {
            UpdateLine();
        }
        else if(!IsCompleted && Input.GetKeyDown(KeyCode.Space))
        {
            GetNewLine();
        }
        else if(IsCompleted && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    private bool Init()
    {
        //reset the variables
        IsLineCompleted = false;
        IsCompleted = false;
        LineIndex = 0;
        CharacterIndex = 0;

        //clear the last display
        Name.text = "";
        Content.text = "";
        NameToDisplay = "";
        DialogToDisplay = "";

        //clear the last display image
        LeftImage.sprite = null;
        LeftImage.enabled = false;
        MiddleImage.sprite = null;
        MiddleImage.enabled = false;
        RightImage.sprite = null;
        RightImage.enabled = false;

        //clean dialogues
        Dialogues = null;

        //reset the countdown timer
        DisplayCountDown = 0;

        return true;
    }

    public bool StartNewDialogues()
    {
        Init();
        gameObject.SetActive(true);

        if(FilePath.Length <= 0)
        {
            Debug.Log("File path is empty.");
            return false;
        }

        //read in the file 
        Dialogues = File.ReadAllLines(FilePath);
        
        //check if the file is empty
        if(Dialogues.Length <= 0)
        {
            Debug.Log("Error! Not able to read in the dialogues file." + FilePath);
            return false;
        }

        //reset the variable
        LineIndex = 0;
        IsCompleted = false;

        if (!GetNewLine())
        {
            Debug.Log("Fail to load dialog file.");
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool GetNewLine()
    {
        //reset the name and dialog display
        NameToDisplay = "";
        DialogToDisplay = "";
        CharacterIndex = 0;

        for (int i = 0; i < 2; ++i)
        {
            if((LineIndex + i) >= Dialogues.Length)
            {
                IsCompleted = true;
                Debug.Log("Error, missing content line, at line " + (LineIndex + i));
                return false;
            }

            //get the name
            if(Dialogues[LineIndex + i].Substring(0, 2) == "N:")
            {
                NameToDisplay = Dialogues[LineIndex + i].Substring(2);
                continue;
            }
            else if(Dialogues[LineIndex + i].Substring(0, 2) == "C:") // get the content
            {
                DialogToDisplay = Dialogues[LineIndex + i].Substring(2);

                //after get the content update the line index and break out
                LineIndex += (i + 1);
                break;
            }

            IsCompleted = true;
            Debug.Log("Error, missing content line, at line " + (LineIndex + i));
            return false;
        }

        if(NameToDisplay == "")
        {
            //disable the Name display since no name need to display
            HideName();
        }
        else
        {
            //able the Name display
            ShowName();
        }

        //if reach the last line
        if (LineIndex >= Dialogues.Length)
        {
            IsCompleted = true;
        }

        IsLineCompleted = false;
        return true;
    }

    public void UpdateLine()
    {
        if(DisplayCountDown >= 0.0001f)
        {
            DisplayCountDown -= Time.deltaTime;
            return;
        }

        CharacterIndex++;
        Content.text = DialogToDisplay.Substring(0,CharacterIndex);

        if(CharacterIndex >= DialogToDisplay.Length)
        {
            IsLineCompleted = true;
        }
        else
        {
            DisplayCountDown = DisplayCoolDowns[0];
        }
    }

    private void ShowName()
    {
        Name.transform.parent.gameObject.SetActive(true);
    }

    private void HideName()
    {
        Name.transform.parent.gameObject.SetActive(false);
    }
}

