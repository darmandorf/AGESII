using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonInteractive : MonoBehaviour, IInteractive
{
    private AudioSource audioSource;

    [SerializeField]
    private Animator doorAnimator;

    public string DisplayText => "Open Door";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void InteractWith()
    {
        Debug.Log("InteractWith was called!");

        if (doorAnimator.GetBool("Closed"))
            doorAnimator.SetBool("Closed", false);
        else
            doorAnimator.SetBool("Closed", true);

        doorAnimator.SetTrigger("DoorButtonPressed");
        audioSource.Play();
    }
}
