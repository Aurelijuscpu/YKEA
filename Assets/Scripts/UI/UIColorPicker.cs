﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorPicker : MonoBehaviour, IPopup
{
    private MeshRenderer _gameObject;

    private Color _newColor;
    private Color _oldColor;

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        FaceCamera();
    }

    public void Show(GameObject mesh)
    {
        transform.position = mesh.transform.position;
        transform.gameObject.SetActive(true);

        _gameObject = mesh.GetComponent<MeshRenderer>();
        _oldColor = _gameObject.material.color;
        _newColor = _oldColor;

        SetSlidersStartingValues();
    }

    public void Hide()
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
        if (_gameObject != null)
            _gameObject.material.SetColor("_BaseColor", _newColor);
        else
        {
            Debug.LogError("Object was destroyed");
            Hide();
        }
    }

    public void RevertToPrevious()
    {
        if (_gameObject != null)
            _gameObject.material.color = _oldColor;
        else
        {
            Debug.LogError("Object was destroyed");
            Hide();
        }
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
