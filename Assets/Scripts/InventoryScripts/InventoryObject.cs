using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object in the inventory screen")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("Text that's displayed when the object is selected in the inventory menu.")]
    [TextArea(1,8)]
    [SerializeField]
    private string descriptionText;

    [Tooltip("Image showed in the inventory for this object.")]
    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;
    public string ObjectName => objectName;
    public string DescriptionText => descriptionText;

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
    /// <summary>
    /// Adds inventory object to the inventory list and removes the object from the world.
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        collider.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
