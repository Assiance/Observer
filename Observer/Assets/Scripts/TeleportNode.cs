using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportNode : MonoBehaviour {
    @RequireComponent AudioSource;
     
    //[HideInInspector]
    public Transform DestinationNode;
    
    public Transform Player;
    public static List<string> NodeNames = new List<string>();
    public static List<Transform> Nodes = new List<Transform>();
    public static List<TeleportNode> NodesRef = new List<TeleportNode>();

    private AudioSource speaker;
    public AudioClip teleport;
    //
    const int DELAY = 30;
    protected static int _Timer = 0;
	
    // Use this for initialization
	void Start () {
        Nodes.Add(this.transform);
        NodeNames.Add(this.gameObject.name + NodeNames.Count.ToString());
        NodesRef.Add(this);

        speaker = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {    
        if (_Timer > 0) _Timer--;
    }
    void OnTriggerEnter()
    {
        if (_Timer == 0 && DestinationNode !=null)
        {
            Player.transform.position = DestinationNode.position;
            speaker.PlayOneShot(teleport);
            _Timer = DELAY;
        }
    }
    public void DrawLinks()
    {
        if(DestinationNode !=null)
        Debug.DrawLine(transform.position, DestinationNode.position, Color.red);
    }
}
