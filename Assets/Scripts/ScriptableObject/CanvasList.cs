using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New popup canvas list", menuName = "Canvas/List")]
public class CanvasList : ScriptableObject
{
    public List<GameObject> canvas;
}
