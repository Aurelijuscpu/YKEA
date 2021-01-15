using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ColorPicker colorPicker;
    public UIPopup uiPopup;

    void HidePopup(GameObject gm)
    {
        gm.SetActive(false);
    }

    void ShowPopup(GameObject gm)
    {
        gm.SetActive(true);
    }
}
