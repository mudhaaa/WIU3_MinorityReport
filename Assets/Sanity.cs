using UnityEngine;

public class Sanity : MonoBehaviour
{
    public SceneFunctions sceneFunctions;

    // Define the delegate type
    public delegate void FloatValueChangedDelegate(float newValue, float newMaxValue);

    // Define the event
    public event FloatValueChangedDelegate SanityChanged;

    // The int value that will trigger the event when changed
    public float sanity;
    [SerializeField] public float maxsanity = 100;

    // Property to get and set the int value
    public float ISanity
    {
        get { return sanity; }
        set
        {
            if (value != sanity)
            {
                sanity = Mathf.Clamp(value, 0, maxsanity);
                // Trigger the event when the value changes
                SanityChanged?.Invoke(sanity, maxsanity);

                if (sanity <= 0)
                {
                    DialogSystem.Instance.onDialogEnd = sceneFunctions.LoadSuicide;
                    DialogSystem.Instance.FilePath = "Assets/Dialog/Ending 5.txt";
                    GameManager.Instance.IsEndingCompleted[4] = true;
                    DialogSystem.Instance.StartNewDialogues();


                }
            }
        }
    }

    // Example usage:
    private void Start()
    {
        ISanity = maxsanity;
        //// Subscribe to the event
        //SanityChanged += DebugLogMessage;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            ISanity -= Time.deltaTime * 5;
        }
    }

    //// Example event handler
    //private void DebugLogMessage(int newValue)
    //{
    //    Debug.Log("Int value changed to: " + newValue);
    //}
}