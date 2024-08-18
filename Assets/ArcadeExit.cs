using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ArcadeExit : MonoBehaviour
{
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject MiniGameUI;
    [SerializeField] BackgroundTransparencyAnim BlackBackground;
    public Volume CameraEffects;
    public VolumeProfile NormalProf;


    bool Exit = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        Exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Exit = true;
            Debug.Log("Arcade Exit");
        }
        if (Exit)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                CameraEffects.profile = NormalProf;
                gameObject.SetActive(false);
                MainGame.SetActive(true);
                if(MiniGameUI != null)
                {
                    MiniGameUI.SetActive(false);
                }
            }
        }
    }
}
