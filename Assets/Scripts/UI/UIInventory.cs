using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private InventorySlot slot;

    private Inventory inventory;
    private InventorySlot[] slots;
    ModelsLoader modelsLoader;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChangedCallback += UpdateUI;

        modelsLoader = FindObjectOfType<ModelsLoader>();

        GenerateSlots();
        slots = transform.GetComponentsInChildren<InventorySlot>();
    }

    void GenerateSlots()
    {
        if(modelsLoader != null)
        {
            for (int i = 0; i < modelsLoader.GameObjects.Count; i++)
            {
                Instantiate(slot.gameObject, transform);
            }
        }
    }

    //Update whole inventory UI
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        { 
            if (i < inventory.Items.Count)
            { 
                slots[i].AddItem(inventory.Items[i]);
            } else
            {
                //Clear slot if dynamic inventory
            }
        }
    }
}
