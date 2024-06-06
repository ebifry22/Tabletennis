using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject leftcontroller;

    // Start is called before the first frame update
    void Start()
    {
        leftcontroller = GameObject.Find("LeftControllerAncor");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left")
        {
            transform.parent = leftcontroller.transform;
        }

    }
}
