using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of Raycast for finding interactibles.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far the Raycast will search.")]
    [SerializeField]
    private float maxRange = 5.0f;

    /// <summary>
    /// Event raised when player looks at a different interactive.
    /// </summary>   
    public static event Action<IInteractive> LookedAtInteractiveChanged;
    public IInteractive LookedtAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;               
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        LookedtAtInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts forward from the camera to look for IInteractives.
    /// </summary>
    /// <returns>The first IInteractive detected or null if none are found.</returns>
    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool ObjectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        LookedtAtInteractive = interactive;

        if (ObjectWasDetected)
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
            //Debug.Log($"Player is looking at {hitInfo.collider.gameObject.name}");
        }      
        
        return interactive;
    }
}
