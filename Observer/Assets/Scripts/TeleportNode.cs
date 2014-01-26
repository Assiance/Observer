using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportNode : MonoBehaviour
{
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
    void Start()
    {
        Nodes.Add(this.transform);
        NodeNames.Add(this.gameObject.name + NodeNames.Count.ToString());
        NodesRef.Add(this);

        speaker = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Timer > 0) _Timer--;
    }
    void OnTriggerEnter()
    {
        if (_Timer == 0 && DestinationNode != null)
        {
            Player.transform.position = DestinationNode.position;
            speaker.PlayOneShot(teleport);
            _Timer = DELAY;


            var RigidBodies = GameObject.FindObjectsOfType(typeof(Rigidbody)).Select(i => (Rigidbody)i).ToList();

            foreach (var bodies in RigidBodies)
            {
                bodies.isKinematic = false;
                bodies.useGravity = false;
                bodies.mass = 1f;
            }

            int count = 1;
            foreach (var bodies in RigidBodies)
            {
                Random.seed = count;
                bodies.velocity = new Vector3(Random.Range(-.3f, .2f), Random.Range(-.3f, .2f), Random.Range(-.3f, .2f));
                bodies.angularVelocity = new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f));
                count++;
            }

        }
    }
    public void DrawLinks()
    {
        if (DestinationNode != null)
            Debug.DrawLine(transform.position, DestinationNode.position, Color.red);
    }
}
