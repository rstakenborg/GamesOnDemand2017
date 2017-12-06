using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulateSpin : MonoBehaviour
{
    public Rigidbody rb;
    public MeshRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.angularVelocity.magnitude < 5)
            rb.angularVelocity = Vector3.Normalize(rb.angularVelocity);
    }
}