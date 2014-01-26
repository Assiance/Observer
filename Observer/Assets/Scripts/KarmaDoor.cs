using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class KarmaDoor : MonoBehaviour {

	//places a requirement of positive or negitive karma on a player
    //the door will slide down (-z by offset) if the player meets the req's
    public int yOffset;
    public int doorRequirement;
  

    private AudioSource stereo;
    public AudioClip sound;

    void Start()
    {
        stereo = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (doorRequirement > 0)
        {
            //pos karma
            if (SceneManager.Instance.Karma >= doorRequirement)
            {
                transform.position = transform.position + new Vector3(0, yOffset, 0);
                stereo.PlayOneShot(sound);
                Destroy(this);
            }
        }
        else
        {
            //negitive karma
            if (SceneManager.Instance.Karma <= doorRequirement)
            {
                transform.position = transform.position + new Vector3(0, yOffset, 0);
                stereo.PlayOneShot(sound);
                Destroy(this);
            }
        }

    }


}
