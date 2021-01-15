using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        } else
        {
            _instance = this;
        }
    }

    #endregion

    public delegate void OnItemChanged();
    public event OnItemChanged OnItemChangedCallback;

    private List<PlacebleItem> _items = new List<PlacebleItem>();
    public List<PlacebleItem> Items { get { return _items; } }

    public void Add(PlacebleItem item)
    {
        _items.Add(item);

        if(OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
