using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonInteractive : MonoBehaviour, IInteractive
{
    private AudioSource audioSource;

    [SerializeField]
    private Animator elevatorAnimator;   

    public string DisplayText => "Call Elevator";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void InteractWith()
    {
        Debug.Log("InteractWith was called!");
        if (elevatorAnimator.GetBool("ElevatorDown"))
            elevatorAnimator.SetBool("ElevatorDown", false);
        else
            elevatorAnimator.SetBool("ElevatorDown", true);

        elevatorAnimator.SetTrigger("ElevatorButtonPressed");
        audioSource.Play();
    }
}
