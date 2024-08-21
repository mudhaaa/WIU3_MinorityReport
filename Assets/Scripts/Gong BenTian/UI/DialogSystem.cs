using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem Instance;

    public delegate void OnDialogEnd();
    public OnDialogEnd onDialogEnd = null;

    public Image Background;

    public Text Content;
    public Text Name;

    public Image LeftImage;
    public Image MiddleImage;
    public Image RightImage;

    public GameObject[] Buttons;
    public Text[] ButtonLabels;

    public string FilePath;
    public string[] Dialogues;
    public int LineIndex;

    public string NameToDisplay;
    public string DialogToDisplay;
    public int CharacterIndex;

    public bool IsLineCompleted;
    private bool nextLine;

    public static readonly float[] DisplayCoolDowns = new float[5]{ 0.05f, 0.1f, 0.2f, 0.4f, 0.6f }; 
    public float DisplayCountDown;

    private int[] LineIndexesJumpTo = null;
    private Dictionary<string, int> ChoiceChosen = null;
    private string newAddedKey;
    private bool isOption;

    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsLineCompleted)
        {
            UpdateLine();
        }
        else if (isOption == false && Input.GetMouseButtonDown(0) && IsLineCompleted == true)
        {
            nextLine = true;
        }

        if (nextLine == true && IsLineCompleted == true)
        {
            if(GetNewLine() == false)
            {
                EndDialog();
            }
        }
    }

    private bool Init()
    {
        //reset the variables
        nextLine = true;
        IsLineCompleted = true;
        LineIndex = 0;
        CharacterIndex = 0;
        isOption = false;

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

        //clear the background display
        Background.sprite = null;
        Background.color = new Color(1, 1, 1, 0);

        //clear the button last display
        for(int i = 0; i < 4; ++i)
        {
            Buttons[i].SetActive(false);
            ButtonLabels[i].text = null;
        }

        ChoiceChosen = new Dictionary<string, int>();

        //clean dialogues
        Dialogues = null;

        //reset the countdown timer
        DisplayCountDown = 0;

        TimeSystem.TimeMultipler = TimeSystem.DialogTimeMultipler;

        return true;
    }

    public bool StartNewDialogues()
    {
        //if the dialog system is running now, reject the start of the new dialogues
        if(gameObject.activeSelf == true)
        {
            Debug.Log("Another dialog is current running.");
            return false;
        }

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

            EndDialog();
            return false;
        }

        //reset the variable
        LineIndex = 0;

        if (!GetNewLine())
        {
            Debug.Log("Fail to load dialog file.");

            EndDialog();
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool GetNewLine()
    {
        if(LineIndex >= Dialogues.Length)
        {
            Debug.Log("Dialogues reached the end.");
            return false;
        }

        //reset the name and dialog display
        NameToDisplay = "";
        DialogToDisplay = "";
        CharacterIndex = 0;
        newAddedKey = "";
        isOption = false;

        for(int i = 0; i < 4; ++i)
        {
            Buttons[i].SetActive(false);
        }

        HideName();

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
                Name.text = Dialogues[LineIndex + i].Substring(2);
                ShowName();
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
                    Background.sprite = Resources.Load<Sprite>("DialogBackground/" + Dialogues[LineIndex + i].Substring(5));
                }

                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 4) == "OPT:") // get options
            {
                string[] temp = Dialogues[LineIndex + i].Substring(4).Split(',');
                int numOfOptionReadIn = 0;

                for(int ii = 0; ii < 10; ii += 2)
                {
                    if (temp[ii] == ">")
                    {
                        newAddedKey = temp[ii + 1];

                        if (ChoiceChosen.ContainsKey(newAddedKey) == false)
                        {
                            ChoiceChosen.Add(newAddedKey, -1);
                        }

                        break;
                    }
                    else
                    {
                        Buttons[numOfOptionReadIn].SetActive(true);
                        ButtonLabels[numOfOptionReadIn].text = temp[ii];
                        ++numOfOptionReadIn;
                    }
                }

                LineIndexesJumpTo = new int[numOfOptionReadIn];

                for (int ii = 0; ii < numOfOptionReadIn; ++ii)
                {
                    LineIndexesJumpTo[ii] = Convert.ToInt32(temp[(ii * 2) + 1]);
                }

                isOption = true;

                continue;
            }
            else if (Dialogues[LineIndex + i].Substring(0, 3) == "END")
            {
                return false;
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

        nextLine = false;
        IsLineCompleted = false;
        return true;
    }

    public void UpdateLine()
    {
        if(Input.GetMouseButtonDown(0) == true || isOption == true)
        {
            CharacterIndex = DialogToDisplay.Length;
            Content.text = DialogToDisplay;
            IsLineCompleted = true;

            return;
        }
        else if(DisplayCountDown >= 0.0001f)
        {
            DisplayCountDown -= Time.deltaTime;
            return;
        }

        CharacterIndex++;

        Content.text = DialogToDisplay.Substring(0, CharacterIndex);

        if (CharacterIndex >= DialogToDisplay.Length)
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

    private void EndDialog()
    {
        TimeSystem.TimeMultipler = TimeSystem.NormalTimeMultipler;
        gameObject.SetActive(false);

        if (onDialogEnd != null)
        {
            onDialogEnd();
            //onDialogEnd = null;
        }
    }

    public void ChooseOption(int optionIndex)
    {   
        if(LineIndexesJumpTo[optionIndex] != -1)
        {
            LineIndex = LineIndexesJumpTo[optionIndex];
        }

        if(newAddedKey != "")
        {
            ChoiceChosen[newAddedKey] = optionIndex;
        }

        nextLine = true;
        return;
    }

    public bool IsCompleted()
    {
        return !gameObject.activeSelf;
    }

    public void SetFilePath(string newPath)
    {
        FilePath = newPath;
    }
}

