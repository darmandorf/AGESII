using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used for Interactive objects that can be switched on/off like switches, buttons, etc.
/// Has a toggle function.
/// </summary>
public class ToggleInteractive : InteractiveObject
{
    [SerializeField]
    private bool isReusable = true;

    [SerializeField]
    private Animator animator;

    private bool hasBeenUsed = false;

    public override void InteractWith()
    {
        if(isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            animator.SetTrigger("Switch");
            hasBeenUsed = true;
            if (!isReusable) displayText = string.Empty;
        }
    }
}
