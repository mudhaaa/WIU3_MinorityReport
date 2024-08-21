using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataSave
{
    public static GameManager Instance;
    public static bool isMale = true;

    public bool[] IsEndingCompleted = new bool[5];

    public bool IsGameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        int EndingCompleted = 0;

        EncodeData(ref EndingCompleted);

        PlayerPrefs.SetInt("EndingCompleted", EndingCompleted);
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("EndingCompleted") == true)
        {
            int temp = PlayerPrefs.GetInt("EndingCompleted");

            for (int i = 0; i < 5; ++i)
            {
                IsEndingCompleted[i] = ((temp % 2) == 1);
                temp = temp >> 1;
            }
        }
    }

    public void ResetData()
    {
        for(int i = 0; i < 5; ++i)
        {
            IsEndingCompleted[i] = false;
        }

        Save();
    }

    private void EncodeData(ref int EndingCompletedData)
    {
        EndingCompletedData = 0;
        for(int i = 0; i < 5; ++i)
        {
            EndingCompletedData += Convert.ToInt32(IsEndingCompleted[i]) << i;
        }
    }

    public void PlayAsMale()
    {
        isMale = true;
    }

    public void PlayAsFemale()
    {
        isMale = false;
    }
}
