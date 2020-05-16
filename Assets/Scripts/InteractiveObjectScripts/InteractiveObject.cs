using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    protected AudioSource audioPlayer;

    public virtual string DisplayText => displayText;
    

    protected virtual void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    public virtual void InteractWith()
    {
        audioPlayer.Play();   
        
        Debug.Log($"Player interacted with {gameObject.name}.");
    }
}
