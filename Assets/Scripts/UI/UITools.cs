using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITools : MonoBehaviour, IPopup
{
    private GameObject _clickedObject;

    private void Start()
    {
        Hide();
    }

    void Update()
    {
        FaceCamera();
    }

    public void Show(GameObject gm)
    {
        gameObject.SetActive(true);
        _clickedObject = gm;
        transform.position = _clickedObject.transform.position;
    }

    public void DestroyObjectButton()
    {
        Destroy(_clickedObject);
    }

    public void EnableMovingButton()
    {
        PlaceController.Instance.SetControllableObject(_clickedObject.GetComponent<PositionChanger>());
    }

    public void ChangeColorButton()
    {
        UIManager.Instance.ShowColorPicker(_clickedObject);
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward * -1;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
