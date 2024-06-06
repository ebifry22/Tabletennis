using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class BallSpwan : MonoBehaviour
{
    [SerializeField] GameObject leftcontroller;
    [SerializeField] GameObject ballprefab;
    [SerializeField] float speed = 5f;

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

    public void Serve(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Serve");
            GameObject ball;
            Rigidbody ballRigidbody;

            ball = Instantiate(ballprefab, leftcontroller.transform.position, Quaternion.identity);

            ballRigidbody = ball.GetComponent<Rigidbody>();

            velocity.x = velocity.z = 0f;
            ballRigidbody.velocity = velocity * speed;

        }
    }
}
