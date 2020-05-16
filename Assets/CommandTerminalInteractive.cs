using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTerminalInteractive : MonoBehaviour, IInteractive
{
    [SerializeField]
    private Animator doorAnimations;

    private AudioSource audioSource;
    public string DisplayText => "Open AI Mainframe Door";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void InteractWith()
    {
        doorAnimations.SetTrigger("ButtonPressed");
        audioSource.Play();
        Debug.Log("The player interacted with the Terminal.");
    }
}
