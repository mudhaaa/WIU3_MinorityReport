using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IOToilet : MonoBehaviour, InteractableObject
{
    public BackgroundTransparencyAnim BlackBackground;
    public DialogSystem dialogSystem;
    public GameObject MiniGameBackground;
    bool Activated = false;
    bool MiniGame = false;
    bool LoadGame = false;
    [SerializeField] float DelayTime = 1.0f;
    public GameObject PickUpZonePrefab;
    public GameObject MiniGameGUI;
    public GameObject MiniGameInteractables;
    GameObject PickUpZone;
    RectTransform PickUpZoneRect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                if (MiniGame)
                {
                    MiniGameBackground.SetActive(true);
                    if (!LoadGame)
                    {
                        //MiniGameBackground.GetComponent<Image>().sprite =
                        // Instantiate the UI element
                        PickUpZone = Instantiate(PickUpZonePrefab, MiniGameGUI.transform);

                        // Get the RectTransform of the instantiated UI element
                        PickUpZoneRect = PickUpZone.GetComponent<RectTransform>();

                        // Get the screen width and height
                        float screenWidth = Screen.width;
                        float screenHeight = Screen.height;

                        // Get the width and height of the UI element
                        float elementWidth = PickUpZoneRect.rect.width;
                        float elementHeight = PickUpZoneRect.rect.height;

                        // Calculate the anchored position
                        Vector2 anchoredPosition = new Vector2(screenWidth - elementWidth , -elementHeight / 2);

                        // Set the anchored position
                        PickUpZoneRect.anchoredPosition3D = new Vector3(anchoredPosition.x, anchoredPosition.y, 0);
                    }
                    LoadGame = true;
                }
                else
                {
                    Destroy(PickUpZone);
                    Destroy(PickUpZoneRect);
                    Activated = false;
                    LoadGame = false;
                    MiniGameBackground.SetActive(false);
                }
            }

            if (Input.GetKey(KeyCode.Escape) && BlackBackground.CoroutineRunning == false)
            {
                MiniGame = false;
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, DelayTime));
            }
        }
    }

    public void Interact()
    {
        dialogSystem.FilePath = "Assets/Dialog/ToiletDialogue.txt";
        dialogSystem.StartNewDialogues();
        Activated = true;
        MiniGame = true;
        BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, DelayTime));
    }

    public void ShowInteractGUI()
    {
    }
}
