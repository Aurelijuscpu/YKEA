using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New models list", menuName = "Placables/List")]
public class ModelsList : ScriptableObject
{
    public List<PlacebleItem> models;
}
