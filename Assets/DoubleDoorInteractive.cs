using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorInteractive : InteractiveObject
{
    private SphereCollider clearDetector;

    [SerializeField]
    private bool isReusable = true;

    [SerializeField]
    private Animator smallDoorAnimator;

    [SerializeField]
    private Animator bigDoorAnimator;

    [SerializeField]
    private GameObject doubleDoors;
    [SerializeField]
    private Light bayLight;

    [SerializeField]
    private GameObject lightFace;

    [SerializeField]
    private Material[] material;

    [SerializeField]
    private AudioClip[] audioClips;

    private MeshRenderer rend;

    private int numberOfCollisions = 0;
    private bool hasBeenUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        clearDetector = gameObject.GetComponent<SphereCollider>();
        rend = lightFace.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckIfClear();
    }

    private void CheckIfClear()
    {
        if (numberOfCollisions == 0)
        {
            smallDoorAnimator.SetBool("DockIsClear", true);
            bayLight.color = Color.green;
            rend.sharedMaterial = material[1];
            audioPlayer.clip = audioClips[1];
        }
        else
        {
            smallDoorAnimator.SetBool("DockIsClear", false);
            bayLight.color = Color.red;
            rend.sharedMaterial = material[0];
            audioPlayer.clip = audioClips[0];
        }
    }

    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            if (numberOfCollisions <= 0)
            {
                smallDoorAnimator.SetTrigger("Switch");
                bigDoorAnimator.SetTrigger("Switch");
                hasBeenUsed = true;
                if (!isReusable) displayText = string.Empty;
            }
            base.InteractWith();           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("0G"))
            numberOfCollisions++;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("0G"))
            numberOfCollisions--;
    }

}
