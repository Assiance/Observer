using UnityEngine;
using System.Collections;

 [RequireComponent(typeof(AudioSource))]
public class Readable : MonoBehaviour {
   
    public TextAsset file;
    private string text;
    public Texture backText;
    private Rect textWindow;
    public int karmaEffect;
    public AudioClip pickup;
    public AudioClip putdown;
    public string hoverText;

    private bool displayHover = false;
    private bool windowOpen = false;
    private bool toBeBurned = false;
    private AudioSource speaker;

    void OnEnable()
    {
        speaker = this.GetComponent<AudioSource>();
        text = file.ToString();
        textWindow = new Rect(25,25,1024,512);
        KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.Escape, ExitWindow);
    }

    void OnGUI()
    {
        if(windowOpen)
        textWindow = GUI.Window(0, textWindow, displayText, "Read Me");

        if (!windowOpen && toBeBurned)
        {
            speaker.PlayOneShot(putdown);
            Destroy(this);
        }

        if (displayHover)
        {
            GUI.Label(new Rect(25, 500, 500, 25), hoverText);
        }
    }

    void displayText(int windID)
    {
        GUI.Label(new Rect(10,30,1004,994), text);
        
    }

    void ExitWindow(KeyCode key)
    {
        if (windowOpen)
        {
            windowOpen = false;
        }
    }

    public void interact()
    {
        windowOpen = true;
        SceneManager.Instance.Karma += karmaEffect;
        toBeBurned = true;
        speaker.PlayOneShot(pickup);

    }

    public void showHoverText()
    {
        displayHover = true;
    }

    public void hideHoverText()
    {
        displayHover = false;
    }
}
