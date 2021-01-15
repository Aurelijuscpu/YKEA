using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New placable model", menuName = "Placables/Object")]
public class PlacebleItem : ScriptableObject
{
    new public string name = "New object";
    public Sprite icon = null;
    public GameObject furniture = null;

    public virtual void Use() {
        var temp = Instantiate(furniture);
        PlaceController.Instance.SetControllableObject(temp.GetComponent<PositionChanger>());
    }
}
