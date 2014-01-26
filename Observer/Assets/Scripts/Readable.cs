using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Readable : MonoBehaviour
{

    public RenderTexture myTexture;

    public TextAsset file;
    private string text;
    public Texture backText;
    private Rect textWindow;
    public int karmaEffect;
    public AudioClip pickup;
    public AudioClip putdown;
    public string hoverText;

    private bool displayHover = false;
    public  bool windowOpen = false;
    private bool toBeBurned = false;
    private AudioSource speaker;

    private Camera LeftCamera;
    private Camera RightCamera;
    private const float CameraWidth = 379.5f;

    protected void OnEnable()
    {
        var cameras = SceneManager.Instance.PlayerOVRCamera.GetComponentsInChildren<Camera>().ToList();
        LeftCamera = cameras[0];
        RightCamera = cameras[1];

        speaker = this.GetComponent<AudioSource>();
        text = file.ToString();
        textWindow = new Rect(30,100,300,200);
        //KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.Escape, ExitWindow);
        
        
    }

    public void DNUOnGUIDNU()
    {
        RenderTexture.active = myTexture;
        GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        if (windowOpen)
        {
            GUI.Window(0, new Rect(100, 200,300,200), displayText, "Read Me");
            //GUI.Window(1, new Rect(100 + CameraWidth, 200, 300, 200), displayText, "Read Me");
        }

        

        if (displayHover)
        {
            //print(LeftCamera.camera.pixelRect);
            //print(RightCamera.camera.pixelRect);
            //OvrGUI.StereoDrawTexture(50, 50, .1f, .1f, RenderTexture.active, Color.white);
            GUI.Label(new Rect(0, 0, 100, 100), hoverText);
            //GUI.Label(new Rect(140 + CameraWidth, 300, 100, 100), hoverText);

        }
        if (!windowOpen && toBeBurned)
        {
            speaker.PlayOneShot(putdown);
            GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            myTexture.DiscardContents();
            Destroy(this);
        }
        RenderTexture.active = null;
        
    }

    void displayText(int windID)
    {
        GUI.Label(new Rect(10, 30, 1004, 994), text);

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
