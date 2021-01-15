using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour
{
    #region Singleton

    private static ClickController _instance;

    public static ClickController Instance { get { return _instance; } }

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

    //Check if callback was finished
    private bool _clickable = true;

    public void SetClickable(bool clickable)
    {
        _clickable = clickable;
    }

    public int targetFPS = 60;

    public delegate void OnPlacableClick(GameObject clicked);
    public event OnPlacableClick OnPlacableClickCallback;

    private void Start()
    {
        Application.targetFrameRate = targetFPS;   //Limit fps
    }

    private void Update()
    {
        if (_clickable)
            Click();
    }

    //Check if click was on a placed object
    private void Click()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("PlacedObject"))
                {
                    if (OnPlacableClickCallback != null)
                        OnPlacableClickCallback.Invoke(hit.transform.gameObject);
                }
            }
        }
    }
}
