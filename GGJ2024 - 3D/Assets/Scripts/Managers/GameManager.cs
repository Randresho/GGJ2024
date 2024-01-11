using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Scripts
    #endregion

    [Header("Persistent Objects")]
    [SerializeField] private GameObject[] persistentObjects = null;

    void Awake()
    {
        foreach (GameObject obj in persistentObjects)
            DontDestroyOnLoad(obj);
    }

    #region Links
    public void Link(string link)
    {
        Application.OpenURL(link);
    }
    #endregion

    #region Exit
    public void AppExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    #endregion
}
