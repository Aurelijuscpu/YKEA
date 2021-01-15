using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

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

    public GameObject introduction;
    public GameObject movingTutorial;

    private void Update()
    {
        if (introduction.activeSelf && Input.anyKeyDown)
        {
            HidePopup(introduction);
        }

        if (PlaceController.Instance.IsMoving())
        {
            ShowPopup(movingTutorial);
        }
        else
        {
            HidePopup(movingTutorial);
        }
    }

    void HidePopup(GameObject gm)
    {
        gm.SetActive(false);
    }

    void ShowPopup(GameObject gm)
    {
        gm.SetActive(true);
    }
}
