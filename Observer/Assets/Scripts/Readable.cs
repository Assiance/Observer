using UnityEngine;
using System.Collections;

public class Readable : MonoBehaviour {
    public TextAsset file;
    private string text;
    public Texture backText;
    private Rect textWindow;

    private bool windowOpen = false;

    void OnEnable()
    {
        text = file.ToString();
        textWindow = new Rect(25,25,1024,512);
        KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.Escape, ExitWindow);
    }

    void OnGUI()
    {
        if(windowOpen)
        textWindow = GUI.Window(0, textWindow, displayText, "Read Me");
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

    }
}
