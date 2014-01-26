﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreezeObjectsEvent : MonoBehaviour
{
    public List<Rigidbody> RigidBodies { get; set; }
    public bool HasTouchedObject = false;

    public void OnEnable()
    {
        RigidBodies = GameObject.FindObjectsOfType(typeof(Rigidbody)).Select(i => (Rigidbody)i).ToList();

        //KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.A, OnFreeze);
    }

    public void Start()
    {
        foreach (var bodies in RigidBodies.Where(i => i.tag == "movable"))
        {
            bodies.isKinematic = true;
        }

        StartCoroutine(FreezeEvent());
    }

    IEnumerator FreezeEvent()
    {
        foreach (var bodies in RigidBodies.Where(i => i.tag == "movable"))
        {
            bodies.isKinematic = false;
        }

        int count = 1;
        yield return new WaitForSeconds(1);

        foreach (var bodies in RigidBodies.Where(i => i.tag == "movable"))
        {
            Random.seed = count;
            bodies.velocity = new Vector3(Random.Range(-.3f, .2f), Random.Range(-.3f, .2f), Random.Range(-.3f, .2f));
            bodies.angularVelocity = new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f), Random.Range(-.2f, .2f));
            count++;
        }
    }
}

