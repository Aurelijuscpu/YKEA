using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private InventorySlot slot;

    private Inventory inventory;
    private InventorySlot[] slots;
    ModelsList modelsLoader;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChangedCallback += UpdateUI;

        modelsLoader = Resources.Load<ModelsList>("ScriptableObjects/Lists/Models");
        if(modelsLoader == null)
        {
            Debug.LogError("ScriptableObjects/Lists/Models File not found");
        }

        GenerateSlots();
        slots = transform.GetComponentsInChildren<InventorySlot>();
    }

    void GenerateSlots()
    {
        if(modelsLoader != null)
        {
            for (int i = 0; i < modelsLoader.models.Count; i++)
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
                //Clear slot method, if dynamic inventory
            }
        }
    }
}
