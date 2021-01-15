using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorPallete : MonoBehaviour
{
    void Update()
    {
        FaceCamera();
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
