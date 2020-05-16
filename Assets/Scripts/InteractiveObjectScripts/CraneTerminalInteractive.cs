using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTerminalInteractive : MonoBehaviour, IInteractive
{
    [SerializeField]
    private Animator craneAnimations;

    private AudioSource audioSource;
    public string DisplayText => "Crane Terminal";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void InteractWith()
    {
        craneAnimations.SetTrigger("TerminalButtonPressed");
        audioSource.Play();
        Debug.Log("The player interacted with the Crane Terminal.");
    }
}
