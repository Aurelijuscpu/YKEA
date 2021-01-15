using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    private MeshRenderer _gameObject;

    private Color _newColor;
    private Color _oldColor;

    private void Start()
    {
        HideColorPicker();
    }

    public void ShowColorPicker(MeshRenderer mesh)
    {
        transform.gameObject.SetActive(true);
        _gameObject = mesh;
        _oldColor = _gameObject.material.color;
        _newColor = _oldColor;

        SetSlidersStartingValues();
    }

    public void HideColorPicker()
    {
        transform.gameObject.SetActive(false);
    }

    private void SetSlidersStartingValues()
    {
        Slider[] slidersRGB = GetComponentsInChildren<Slider>();
        for (int i = 0; i < slidersRGB.Length; i++)
        {
            if (slidersRGB[i].gameObject.name == "Red")
            {
                slidersRGB[i].value = _oldColor.r;
            }
            else if (slidersRGB[i].gameObject.name == "Green")
            {
                slidersRGB[i].value = _oldColor.g;
            }
            else if (slidersRGB[i].gameObject.name == "Blue")
            {
                slidersRGB[i].value = _oldColor.b;
            }
        }
    }

    public void RChannel(float value)
    {
        _newColor.r = value; 
    }

    public void BChannel(float value)
    {
        _newColor.b = value;
    }

    public void GChannel(float value)
    {
        _newColor.g = value;
    }

    public void ApplyColor()
    {
        _gameObject.material.SetColor("_BaseColor", _newColor);
    }

    public void RevertToPrevious()
    {
        _gameObject.material.color = _oldColor;
    }
}
