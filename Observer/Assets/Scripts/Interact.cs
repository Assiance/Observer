using UnityEngine;
using System.Collections;


public class Interact : MonoBehaviour {

	//Used to detect interaction through collision
    private bool inColl = false;


    void OnTriggerStay(Collider coll)
    {
        Debug.Log("blue flag");
        if (coll.gameObject.tag == "Interactable" && KeyboardEventManager.InteractKeyPress)
        {
            Debug.Log("red flag");
            if (coll.gameObject.GetComponent(typeof(Readable)) != null)
            {
                Readable contact = (Readable)coll.gameObject.GetComponent(typeof(Readable));
                contact.interact();
            }
            
        }
    }
}
