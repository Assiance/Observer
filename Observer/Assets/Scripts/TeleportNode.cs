using UnityEngine;
using System.Collections;

public class TeleportNode : MonoBehaviour {

    public Transform DestinationNode;
    public Transform Player;

    //
    const int DELAY = 30;
    protected static int _Timer = 0;
	
    // Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        
        if (_Timer > 0) _Timer--;

        Debug.DrawLine(transform.position, DestinationNode.position, Color.red);
	}
    void OnCollisionEnter()
    {
        if (_Timer == 0 && DestinationNode !=null)
        {
            Player.transform.position = DestinationNode.position;
            _Timer = DELAY;
        }
    }
}
