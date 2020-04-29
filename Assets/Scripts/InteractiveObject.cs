using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    public void InteractWith()
    {
        try
        {
            audioPlayer.Play();
        }
        catch (System.Exception)
        {

            throw new System.Exception("Object is missing AudioSource component.");
        }
        Debug.Log($"Player interacted with {gameObject.name}.");
    }
}
