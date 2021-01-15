using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorPallete : MonoBehaviour
{
    private ColorPicker colorPicker;

    // Start is called before the first frame update
    void Start()
    {
        colorPicker = GetComponentInChildren<ColorPicker>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceCamera();
    }

    void HideColorPicker()
    {
        colorPicker.gameObject.SetActive(false);
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
