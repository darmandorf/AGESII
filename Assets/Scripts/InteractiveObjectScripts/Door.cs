using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door, if the key is in the player inventory it will open.")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("If this is checked, the associated key will be removed from the player inventory.")]
    [SerializeField]
    private bool consumesKey;

    [Tooltip("Display text for when the door is locked.")]
    [SerializeField]
    private string lockedDisplayText;

    [Tooltip("Clip played when interacted with when the player doesn't have the key.")]
    [SerializeField]
    private AudioClip lockedAudio;

    [Tooltip("Clip played when interacted with when the player has the key.")]
    [SerializeField]
    private AudioClip unlockedAudio;

    //Uses the ? ternary operator. Basically an if with two options, one before the : and one after.
    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;
            if (isLocked)
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.displayText;

            return toReturn;
        }       
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
    private int shouldOpenAnimParameter = Animator.StringToHash(nameof(shouldOpenAnimParameter));

    public Door()
    {
        displayText = nameof(Door);
    }
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;    
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                audioPlayer.clip = lockedAudio;
            }
            else //Not locked or locked and has key
            {
                audioPlayer.clip = unlockedAudio;
                animator.SetTrigger(shouldOpenAnimParameter);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith();// Plays a sound
        }       
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key);
        }
    }
}
