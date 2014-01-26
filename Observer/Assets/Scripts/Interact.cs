using UnityEngine;
using System.Collections;


public class Interact : MonoBehaviour
{
    public RenderTexture MyTexture;
    //Used to detect interaction through collision
    private bool inColl = false;
    public Readable contact = null;

    void Start()
    {
        KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.Escape, ExitWindow);
    }

    public void ExitWindow(KeyCode key)
    {
        contact = null;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Interactable")
        {
            if (coll.gameObject.GetComponent(typeof(Readable)) != null)
            {
                contact = (Readable)coll.gameObject.GetComponent<Readable>();
                contact.showHoverText();
            }
        }
    }

    void OnTriggerStay(Collider coll)
    {

        if (contact != null && KeyboardEventManager.InteractKeyPress)
        {


            contact.interact();

        }

        //if (coll.gameObject.tag == "PickUp" && KeyboardEventManager.InteractKeyPress)
        //{
        //    if (coll.gameObject.GetComponent(typeof(PickupAble)) != null)
        //    {
        //        PickupAble contact = (PickupAble)coll.gameObject.GetComponent(typeof(PickupAble));
        //        contact.interact();
        //    }
        //}
    }

    void OnTriggerExit(Collider coll)
    {
        contact = null;
    }
    void displayText(int windID)
    {

        GUI.Label(new Rect(10, 30, 300, 200), contact.file.ToString());
    }
    public void OnGUI()
    {

        if (contact == null)
        {
            RenderTexture.active = MyTexture;
            GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            RenderTexture.active = null;
            return;
        }


        RenderTexture.active = MyTexture;
        GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        if (contact.windowOpen)
        {
            GL.Clear(false, true, new Color(.9f,.9f,.88f,1));
            GUI.Label(new Rect(10, 30, 500, 400), contact.file.ToString());
            //GUI.Window(0, new Rect(100, 200, 300, 200), displayText, "Read Me");
        }

        else
            GUI.Label(new Rect(200,200, 395, 395), contact.hoverText);

        //GUI.Window(1, new Rect(100 + CameraWidth, 200, 300, 200), displayText, "Read Me");



        RenderTexture.active = null;

    }
}