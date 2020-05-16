using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandTerminalInteractive : InteractiveObject
{
    [SerializeField]
    private InventoryObject coordinateData;

    [SerializeField]
    private InventoryObject aiOverrideKey;

    [SerializeField]
    private AudioClip errorSound;

    [SerializeField]
    private AudioClip successSound;

    [SerializeField]
    private GameObject voiceLine;

    private bool hasData => PlayerInventory.InventoryObjects.Contains(coordinateData);
    private bool hasOverride => PlayerInventory.InventoryObjects.Contains(aiOverrideKey);
    private bool hasDataEntered = false;


    protected override void Awake()
    {
        base.Awake();
        displayText = "Please Enter Coordinate Data.";
    }
    public override void InteractWith()
    {
        if (!hasData && !hasDataEntered)
        {
            audioPlayer.clip = errorSound;
            displayText = "No coordinate data found.";
        }
        else if(hasData & !hasDataEntered)
        {
            audioPlayer.clip = successSound;
            audioPlayer.Play();
            hasDataEntered = true;
            PlayerInventory.InventoryObjects.Remove(coordinateData);
            displayText = "Coordinate data uploaded. Please wait...";
            StartCoroutine("ProcessData");
            
        }
        else if(hasDataEntered && hasOverride)
        {
            audioPlayer.clip = successSound;
            PlayerInventory.InventoryObjects.Remove(aiOverrideKey);
            displayText = "Override Accepted. Station de-orbit in process...";
        }
        base.InteractWith();
    }
    private IEnumerator ProcessData()
    {
        yield return new WaitForSeconds(3);
        displayText = "Warning! AI Override Enabled! Please disable override to continue.";
        audioPlayer.clip = errorSound;
        audioPlayer.Play();
        voiceLine.SetActive(true);
    }
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
