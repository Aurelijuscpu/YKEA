using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    PlacebleItem item;

    public void AddItem(PlacebleItem newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
