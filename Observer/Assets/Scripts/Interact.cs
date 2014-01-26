using UnityEngine;
using System.Collections;


public class Interact : MonoBehaviour {

	//Used to detect interaction through collision
    private bool inColl = false;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Interactable")
        {
            
               
                if (coll.gameObject.GetComponent(typeof(Readable)) != null)
                {
                    Readable contact = (Readable)coll.gameObject.GetComponent(typeof(Readable));
                    contact.showHoverText();
                }
            


        }
    }

    void OnTriggerStay(Collider coll)
    {
        
        if (coll.gameObject.tag == "Interactable" && KeyboardEventManager.InteractKeyPress)
        {
            
                
                if (coll.gameObject.GetComponent(typeof(Readable)) != null)
                {
                    Readable contact = (Readable)coll.gameObject.GetComponent(typeof(Readable));
                    contact.interact();
                }
            

            
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Interactable")
        {


            if (coll.gameObject.GetComponent(typeof(Readable)) != null)
            {
                Readable contact = (Readable)coll.gameObject.GetComponent(typeof(Readable));
                contact.hideHoverText();
            }



        }
    }
}
