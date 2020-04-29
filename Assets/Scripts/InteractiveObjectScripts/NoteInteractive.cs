using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteractive : MonoBehaviour, IInteractive
{
    public string DisplayText => "Scribbled note";

    public void InteractWith()
    {
        Debug.Log("The player interacted with the note.");
        //TODO: Make the note a part of the inventory system
    }
}
