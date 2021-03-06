﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsLoader : MonoBehaviour
{
    public static string PLACEDTAG = "PlacedObject"; 

    private ModelsList _list;

    void Start()
    {
        Invoke("Delay", 0); //Bug of inventory fix
    }

    void Delay()
    {
        _list = Resources.Load<ModelsList>("ScriptableObjects/Lists/Models");
        if (_list == null)
        {
            Debug.LogError("ScriptableObjects/Lists/Models File not found");
            return;
        }

        for (int i = 0; i < _list.models.Count; i++)
        {
            AdaptModel(_list.models[i].furniture);
            Inventory.Instance.Add(_list.models[i]);
        }
    }

    void AdaptModel(GameObject temp)
    {
        if (temp.GetComponent<Collider>() == null)
            temp.AddComponent<MeshCollider>();
        if (!temp.CompareTag(PLACEDTAG))
            temp.tag = PLACEDTAG;
        if (temp.GetComponent<PositionChanger>() == null)
            temp.AddComponent<PositionChanger>();
    }
}
