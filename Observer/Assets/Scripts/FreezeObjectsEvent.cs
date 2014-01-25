using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class FreezeObjectsEvent : MonoBehaviour
    {
        public List<Rigidbody> RigidBodies { get; set; }

        public void OnEnable()
        {
            RigidBodies = GameObject.FindObjectsOfType(typeof(Rigidbody)).Select(i => (Rigidbody)i).ToList();

            KeyboardEventManager.Instance.RegisterKeyDown(KeyCode.A, OnFreeze);
        }

        public void Start()
        {
            foreach (var bodies in RigidBodies)
            {
                bodies.velocity = Vector3.zero;
                bodies.rotation = new Quaternion(0,0,0,0);
                bodies.angularVelocity = Vector3.zero;
            }
        }

        public void OnFreeze(KeyCode key)
        {
            foreach (var bodies in RigidBodies)
            {
                bodies.velocity = Vector3.zero;
                bodies.rotation = new Quaternion(0, 0, 0, 0);
                bodies.angularVelocity = Vector3.zero;
            }
        }
    }
}
