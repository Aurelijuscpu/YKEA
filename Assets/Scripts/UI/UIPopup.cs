using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    private GameObject _gameObject;

    UIColorPicker colorPicker;

    private CanvasList _canvasList;

    private void Start()
    {
        _canvasList = Resources.Load<CanvasList>("ScriptableObjects/Lists/Canvas");
        GetUIItem();

        ClickController.Instance.OnPlacableClickCallback += ShowPopup;
        HidePopup();
    }

    private void GetUIItem()
    {
        for (int i = 0; i < _canvasList.canvas.Count; i++)
        {
            if (_canvasList.canvas[i].gameObject.CompareTag("ColorPicker"))
            {
                colorPicker = _canvasList.canvas[i].GetComponent<UIColorPicker>();
            }
        }
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
        var temp = Instantiate(colorPicker.gameObject);
        Debug.Log(temp);
        temp.GetComponent<UIColorPicker>().ShowColorPicker(_gameObject.GetComponent<MeshRenderer>());
    }

    private void FaceCamera()
    {
        transform.forward = Camera.main.transform.forward * -1;
    }
}
