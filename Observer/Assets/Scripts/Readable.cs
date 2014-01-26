using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Readable : MonoBehaviour
{

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

    private Camera LeftCamera;
    private Camera RightCamera;
    private const float CameraWidth = 379.5f;

    void OnEnable()
    {
        var cameras = SceneManager.Instance.PlayerOVRCamera.GetComponentsInChildren<Camera>().ToList();
        LeftCamera = cameras[0];
        RightCamera = cameras[1];

        speaker = this.GetComponent<AudioSource>();
        text = file.ToString();
        textWindow = new Rect(30,100,300,200);
        KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.Escape, ExitWindow);
    }

    void OnGUI()
    {
        if (windowOpen)
        {
            GUI.Window(0, new Rect(210, 200,300,200), displayText, "Read Me");
            GUI.Window(1, new Rect(210 + CameraWidth, 200, 300, 200), displayText, "Read Me");
        }

        if (!windowOpen && toBeBurned)
        {
            speaker.PlayOneShot(putdown);
            Destroy(this);
        }

        if (displayHover)
        {
            print(LeftCamera.camera.pixelRect);
            print(RightCamera.camera.pixelRect);
            GUI.Label(new Rect(140, 300, 100, 100), hoverText);
            GUI.Label(new Rect(140 + CameraWidth, 300, 100, 100), hoverText);

        }
    }

    void displayText(int windID)
    {
        GUI.Label(new Rect(10, 30, 290, 190), text);

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
