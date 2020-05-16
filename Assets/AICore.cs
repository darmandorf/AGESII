using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore : MonoBehaviour
{
    private Animator animator;
    private SphereCollider detector;
    private int numberOfRings = 3;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        detector = gameObject.GetComponent<SphereCollider>();
    }

    private void FixedUpdate()
    {
        if (numberOfRings <= 0)
            animator.SetTrigger("Switch");
    }

    public void OnTriggerExit(Collider other)
    {
        numberOfRings--;
    }
}
