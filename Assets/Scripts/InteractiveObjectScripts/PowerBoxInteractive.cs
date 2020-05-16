using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxInteractive : MonoBehaviour, IInteractive
{
    private Animation leverPull;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject lever;

    [SerializeField]
    private GameObject lightParent;

    private bool animPlayed = false;

    private void Awake()
    {
        leverPull = lever.GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }
    public string DisplayText => "Powerbox";

    public void InteractWith()
    {
        if(!animPlayed)
        {
            leverPull.Play();
            audioSource.Play();
            lightParent.SetActive(true);
            animPlayed = true;
        }
    }

}
