using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRingRotation : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool spinLeft;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if(!spinLeft)
            rb.AddRelativeTorque(Vector3.up * speed, ForceMode.Impulse);
        else
            rb.AddRelativeTorque(Vector3.down * speed, ForceMode.Impulse);
    }
}
