using UnityEngine;
using System.Collections;

public class EventSensor : MonoBehaviour {
    
    public int KarmaEffect = 0;
    public int MaxSteps = 300;
    public bool AllowPartialKarma = false;
    public Transform AimTarget;
    public Transform Player;
    public bool UseAimTarget = false;
    [Range(0, 1)]
    public float Accuracy = 0.99f;

    //Better Aim earn faster
    public bool UseAimAccuracyForTime = false;

    private float _KarmaEarned = 0;
    private float _totalEarned = 0;
    private Transform LookAt;
	// Use this for initialization
	void Start () {
         
        transform.LookAt(AimTarget);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter()
    {
        _KarmaEarned = 0;
        Debug.Log("Triggered");
    }
    void OnTriggerStay()
    {
        //Debug.Log(_KarmaEarned);
        if (UseAimTarget)
        {
            float Dot = Mathf.Max(Quaternion.Dot(transform.rotation,Player.transform.rotation),0);
            //Debug.Log(Dot);
            if (UseAimAccuracyForTime)
                _KarmaEarned += Dot * Dot * Dot;
            else
                if (Dot > Accuracy) _KarmaEarned++;
        }
        else
            _KarmaEarned++;


        if (_KarmaEarned >= MaxSteps)
        {
            SceneManager.Instance.Karma += KarmaEffect;
            Destroy(this);
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("unTriggered");
        if (AllowPartialKarma)
        {
        float Added = Mathf.Floor(_KarmaEarned / (float)MaxSteps * (float)KarmaEffect);
        _totalEarned +=Mathf.Abs(Added);
        if (_totalEarned < Mathf.Abs(KarmaEffect)) 
            SceneManager.Instance.Karma += (int)Added;
        else
            Destroy(this);
        }
        else
            if (_KarmaEarned >= MaxSteps)
            {
                SceneManager.Instance.Karma += KarmaEffect;
                Destroy(this);
            }
    }
}

