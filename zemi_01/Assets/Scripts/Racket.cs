using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Racket : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] XRNode node;

    [SerializeField] bool tracked = false;
    [SerializeField] Vector3 position;
    [SerializeField] Quaternion rotation;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 acceleration;
    [SerializeField] Vector3 angularVelocity;
    [SerializeField] Vector3 angularAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<XRNodeState> states = new List<XRNodeState>();
        InputTracking.GetNodeStates(states);

        foreach (XRNodeState s in states)
        {
            if (s.nodeType == node)
            {
                tracked = s.tracked;
                s.TryGetPosition(out position);
                s.TryGetRotation(out rotation);
                s.TryGetVelocity(out velocity);
                s.TryGetAcceleration(out acceleration);
                s.TryGetAngularVelocity(out angularVelocity);
                s.TryGetAngularAcceleration(out angularAcceleration);
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("Ball touch");
            Vector3 Force;
            Force = new Vector3(0, 0, 0.1f);
            other.GetComponent<Rigidbody>().velocity += velocity * speed;
            //other.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
        }
    }
}
