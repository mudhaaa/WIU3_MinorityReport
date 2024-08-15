using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunctions
{
    private SceneFunctions()
    {
        return;
    }

    public static void ChangeSceneTo(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
