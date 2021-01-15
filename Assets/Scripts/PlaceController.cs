using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceController : MonoBehaviour
{
    #region Singleton

    private static PlaceController _instance;

    public static PlaceController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    private PositionChanger _controllableObject;

    //Allow manipulations with _controllableObject
    private bool _moving;    

    public void SetControllableObject(PositionChanger gameObject)
    {
        if (_moving)
            Destroy(_controllableObject.gameObject);

        _moving = true;
        _controllableObject = gameObject;
    }

    void Update()
    {
        if (_moving) {
            RotateObject();
            MoveObject();
            Cancel();
            StopMoving();
        }
    }

    public bool IsMoving()
    {
        return _moving;
    }

    void StopMoving()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _moving = false;
        }
    }

    void Cancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _moving = false;
            Destroy(_controllableObject.gameObject);
        }
    }

    void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.name == "Ground")
            {
                _controllableObject.MoveToPosition(hits[i].point);
            }
        }
    }

    void RotateObject()
    { 
        if (Input.GetKey(KeyCode.Q))
        {
            _controllableObject.RotateAroundYLeft();
        }

        if (Input.GetKey(KeyCode.E))
        {
            _controllableObject.RotateAroundYRight();
        } 
    }
}
