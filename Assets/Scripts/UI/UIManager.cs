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

    private MainCanvas _mainCanvasLink;
    private CanvasList _canvasList;

    private GameObject _mainCanvas;
    private GameObject _colorPickerUI;
    private GameObject _toolsUI;
    private GameObject _introductionUI;
    private GameObject _movingTutorialUI;

    private void Start()
    {
        GetUIPrefabs();
        GetUIItem();
        InstantiateUI();

        ClickController.Instance.OnPlacableClickCallback += ShowTools;
    }

    private void Update()
    {
        if (_introductionUI.activeSelf && Input.anyKeyDown)
            _introductionUI.SetActive(false);

        if (PlaceController.Instance.IsMoving())
            _movingTutorialUI.SetActive(true);
        else
            _movingTutorialUI.SetActive(false);
    }

    private void InstantiateUI()
    {
        _mainCanvas = Instantiate(_mainCanvasLink.canvas.gameObject);
        _toolsUI = Instantiate(_toolsUI.gameObject);
        _colorPickerUI = Instantiate(_colorPickerUI.gameObject);
        _introductionUI = Instantiate(_introductionUI, _mainCanvas.transform);
        _movingTutorialUI = Instantiate(_movingTutorialUI, _mainCanvas.transform);
    }

    private void GetUIPrefabs()
    {
        _canvasList = Resources.Load<CanvasList>("ScriptableObjects/Lists/Canvas");
        if (_canvasList == null)
        {
            Debug.LogError("ScriptableObjects/Lists/Canvas file not found");
            return;
        }

        _mainCanvasLink = Resources.Load<MainCanvas>("ScriptableObjects/MainCanvas");
        if (_mainCanvasLink == null)
        {
            Debug.LogError("ScriptableObjects/MainCanvas file not found");
            return;
        }
    }

    private void GetUIItem()
    {
        for (int i = 0; i < _canvasList.canvas.Count; i++)
        {
            if (_canvasList.canvas[i].gameObject.CompareTag("ColorPicker"))
                _colorPickerUI = _canvasList.canvas[i];
            if (_canvasList.canvas[i].gameObject.CompareTag("Tools"))
                _toolsUI = _canvasList.canvas[i];
            if (_canvasList.canvas[i].gameObject.CompareTag("Introduction"))
                _introductionUI = _canvasList.canvas[i];
            if (_canvasList.canvas[i].gameObject.CompareTag("MovingTutorial"))
                _movingTutorialUI = _canvasList.canvas[i];
        }
    }

    public void HideTools()
    {
        _toolsUI.GetComponent<IPopup>().Hide();
    }

    public void ShowTools(GameObject clickedObject)
    {
        _toolsUI.GetComponent<IPopup>().Show(clickedObject);
    }

    public void ShowColorPicker(GameObject clickedObject)
    {
        _colorPickerUI.GetComponent<IPopup>().Show(clickedObject);
    }

    public void HideColorPicker()
    {
        _colorPickerUI.GetComponent<IPopup>().Hide();
    }
}
