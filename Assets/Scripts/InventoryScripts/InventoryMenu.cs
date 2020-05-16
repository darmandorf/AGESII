using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    #region AudioClips
    [SerializeField]
    private AudioClip openInventoryClip;

    [SerializeField]
    private AudioClip closeInventoryClip;
    #endregion

    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [SerializeField]
    private Transform inventoryListContentArea;

    [Tooltip("Name of the object being looked at in the inventory.")]
    [SerializeField]
    private Text itemLabelText;

    [Tooltip("Description of the object being looked at in the inventory.")]
    [SerializeField]
    private Text itemDescriptionText;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController playerController;
    private AudioSource audioSource;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is no InventoryMenu instance in the scene");
            return instance;
        }
        private set { instance = value; }
    }

    private bool isVisible => canvasGroup.alpha > 0;


    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;

    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Show Inventory Menu"))
            if (isVisible)
                HideMenu();
            else ShowMenu();
    }

    private void ShowMenu()
    {
        audioSource.clip = openInventoryClip;
        audioSource.Play();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        playerController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMenu()
    {
        audioSource.clip = closeInventoryClip;
        audioSource.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvasGroup.alpha = 0;       
        canvasGroup.interactable = false;
        playerController.enabled = true;       
    }

    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        itemDescriptionText.text = inventoryObjectThatWasSelected.DescriptionText;
    }

    /// <summary>
    /// Event handler for InventoryMenuItemSelected.
    /// </summary>
    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }
    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {       
        HideMenu();
        StartCoroutine("WaitForAudioClip");              
    }

    private IEnumerator WaitForAudioClip()
    {
        float preferredAudioLevel = audioSource.volume;
        audioSource.volume = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.volume = preferredAudioLevel;
    }
}
