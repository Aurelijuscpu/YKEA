using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    private GameObject _gameObject;
    ColorPicker colorPalleteUI;

    private void Start()
    {
        colorPalleteUI = FindObjectOfType<ColorPicker>();
        ClickController.Instance.OnPlacableClickCallback += ShowPopup;
        HidePopup();
    }

    void Update()
    {
        FaceCamera();
        if (Input.GetMouseButtonDown(1))
        {
            HidePopup();
        }
    }

    void ShowPopup(GameObject gm)
    {
        _gameObject = gm;
        gameObject.SetActive(true);
        transform.position = _gameObject.transform.position;
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }

    public void DestroyObject()
    {
        Destroy(_gameObject);
    }

    public void EnableMoving()
    {
        PlaceController.Instance.SetControllableObject(_gameObject.GetComponent<PositionChanger>());
    }

    public void ChangeColor()
    {
        colorPalleteUI.ShowColorPicker(_gameObject.GetComponent<MeshRenderer>());
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward * -1;
    }
}
