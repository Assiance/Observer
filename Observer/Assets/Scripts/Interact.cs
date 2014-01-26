using UnityEngine;
using System.Collections;


public class Interact : MonoBehaviour {

	//Used to detect interaction through collision
    private bool inColl = false;

    void OnTriggerEnter(Collider coll)
    {
      checkInteract(coll);
    }

    void OnTriggerStay(Collider coll)
    {
      checkInteract(coll);
    }

    void OnTriggerExit(Collider coll)
    {
      checkInteract(coll);
    }

    void checkInteract(Collider coll)
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
}
