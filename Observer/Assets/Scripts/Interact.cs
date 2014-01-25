using UnityEngine;
using System.Collections;


public class Interact : MonoBehaviour {

	//Used to detect interaction through collision

    void OnCollisionEnter(Collision coll)
    {
        if ( KeyboardEventManager.InteractKeyPress && coll.gameObject.tag == "Interactable" )
        {
            if (coll.gameObject.GetComponent(typeof(Readable)) != null)
            {
                Readable contact = (Readable)coll.gameObject.GetComponent(typeof(Readable));
                contact.interact();
            }
            
        }
    }
}
