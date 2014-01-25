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
    }

    void OnGUI()
    {
        if(windowOpen)
        textWindow = GUI.Window(0, textWindow, displayText, "Read Me");
    }

    void displayText(int windID)
    {
        GUI.Label(new Rect(10,30,1004,994), text);
        if (GUI.Button(new Rect(990, 5, 25, 25), "x"))
        {
            windowOpen = false;
        }
    }

    public void interact()
    {
        windowOpen = true;

    }
}
