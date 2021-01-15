using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsLoader : MonoBehaviour
{
    [SerializeField]
    private List<PlacebleItem> _gameObjects;

    public List<PlacebleItem> GameObjects { get { return _gameObjects; } }

    void Start()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            Inventory.Instance.Add(_gameObjects[i]);
        }
    }
}
