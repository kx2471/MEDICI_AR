using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartpin : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 force;

    enum State
    {
        Normal,
        Shoot,
    }
    State state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        state = State.Normal;

    }

    public void Shoot()
    {
        if (state == State.Normal)
        {
            rb.isKinematic = false;
            rb.velocity = force;
            state = State.Shoot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Shoot)
        {
            rb.transform.forward = rb.velocity;
        }
    }

    internal void SetNormal()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        state = State.Normal;
        rb.transform.forward = Vector3.forward;
    }
}