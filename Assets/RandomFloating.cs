using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloating : MonoBehaviour
{
    [SerializeField]
    private float minForce = -1f;

    [SerializeField]
    private float maxForce = 1f;
    private Rigidbody rb;

    private void Awake()
    {
        if (gameObject.CompareTag("0G"))
        {
            rb = gameObject.GetComponent<Rigidbody>();

            rb.AddRelativeTorque(CreateRandomVector(), ForceMode.Impulse);
            rb.AddRelativeForce(CreateRandomVector(), ForceMode.Impulse);
        }
    }
    private Vector3 CreateRandomVector()
    {
        Vector3 randomDirection = new Vector3(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce), Random.Range(minForce, maxForce));
        return randomDirection;
    }
}
