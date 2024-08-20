using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable object/SceneFunctions")]
public class SceneFunctions : ScriptableObject
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        return;
    }

    public void LoadMaleBE()
    {
        SceneManager.LoadScene("Hit your wife");
        return;
    }
    
    public void LoadGeneralBE()
    {
        SceneManager.LoadScene("Die Screen");
        return;
    }

    public void LoadMaleGE()
    {
        SceneManager.LoadScene("Win as man");
        return;
    }

    public void LoadFemaleGE()
    {
        SceneManager.LoadScene("Win as Female");
        return;
    }

    public void LoadSuicide()
    {
        SceneManager.LoadScene("Lose Screen");
        return;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
