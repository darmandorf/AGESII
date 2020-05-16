using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderInteractive : MonoBehaviour, IInteractive
{
    public string DisplayText => "Climb Ladder";

    public void InteractWith()
    {
        SceneManager.LoadScene(2);
    }
}
