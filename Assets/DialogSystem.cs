using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Image Background;

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
            if(!GetNewLine())
            {
                gameObject.SetActive(false);
            }
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

        for (int i = 0; i < 7; ++i)
        {
            if((LineIndex + i) >= Dialogues.Length)
            {
                Debug.Log("Error, missing content line, at line " + (LineIndex + i));
                return false;
            }

            //get the name
            if(Dialogues[LineIndex + i].Substring(0, 2) == "N:")
            {
                NameToDisplay = Dialogues[LineIndex + i].Substring(2);
                continue;
            }
            else if(Dialogues[LineIndex + i].Substring(0, 4) == "LIM:")
            {
                if (Dialogues[LineIndex + i].Substring(4) == "Null")
                {
                    LeftImage.sprite = null;
                    LeftImage.enabled = false;
                }
                else 
                {
                    LeftImage.enabled = true;
                    LeftImage.sprite = Resources.Load<Sprite>("DialogImages/" + Dialogues[LineIndex + i].Substring(4));
                }

                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 4) == "RIM:")
            {
                if (Dialogues[LineIndex + i].Substring(4) == "Null")
                {
                    RightImage.sprite = null;
                    RightImage.enabled = false;
                }
                else
                {
                    RightImage.enabled = true;
                    RightImage.sprite = Resources.Load<Sprite>("DialogImages/" + Dialogues[LineIndex + i].Substring(4));
                }

                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 4) == "MIM:")
            {
                if (Dialogues[LineIndex + i].Substring(4) == "Null")
                {
                    MiddleImage.sprite = null;
                    MiddleImage.enabled = false;
                }
                else
                {
                    MiddleImage.enabled = true;
                    MiddleImage.sprite = Resources.Load<Sprite>("DialogImages/" + Dialogues[LineIndex + i].Substring(4));
                }

                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 7) == "BGRGBA:")
            {
                string[] colorValues = Dialogues[LineIndex + i].Substring(7).Split(',');
                if(colorValues.Length < 4 && colorValues.Length > 4)
                {
                    Debug.Log("Fail to change the background color, invalid color information. At Line " + (LineIndex + i));
                    continue;
                }

                Color newColor = new Color(0, 0, 0, 0);
                float temp = 0.0f;
                for(int ii = 0; ii < 4; ++ii)
                {
                    temp = Convert.ToSingle(colorValues[ii]);
                    temp = Mathf.Clamp(temp, 0, 255);

                    switch(ii)
                    {
                        case 0:
                            {
                                newColor.r = (temp / 255.0f);
                                break;
                            }
                        case 1:
                            {
                                newColor.g = (temp / 255.0f);
                                break;
                            }
                        case 2:
                            {
                                newColor.b = (temp / 255.0f);
                                break;
                            }
                        case 3:
                            {
                                newColor.a = (temp / 255.0f);
                                break;
                            }
                    }
                }

                Background.color = newColor;
                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 5) == "BGIM:")
            {
                if (Dialogues[LineIndex + i].Substring(5) == "Null")
                {
                    Background.sprite = null;
                }
                else
                {
                    Background.sprite = Resources.Load<Sprite>("DialogImages/" + Dialogues[LineIndex + i].Substring(5));
                }

                continue;
            }
            else if(Dialogues[LineIndex + i].Substring(0, 2) == "C:") // get the content
            {
                DialogToDisplay = Dialogues[LineIndex + i].Substring(2);

                //after get the content update the line index and break out
                LineIndex += (i + 1);
                break;
            }

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

