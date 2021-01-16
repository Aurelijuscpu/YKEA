using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

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

    public int targetFPS = 60;

    private void Start()
    {
        Application.targetFrameRate = targetFPS;   //Limit fps
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void SaveData()
    {

    }

    void LoadData()
    {

    }
}
