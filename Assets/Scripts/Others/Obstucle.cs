using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstucle : MonoBehaviour
{
    Rigidbody rb;
    bool triggered = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (triggered)
            return;

        rb.isKinematic = false;
        triggered = true;
    }
}
