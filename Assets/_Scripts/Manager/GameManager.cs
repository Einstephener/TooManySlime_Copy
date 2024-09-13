using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private static bool _initialized;

    #region Field

    [HideInInspector] public bool isFight = false;
    [HideInInspector] public bool isEnd = false;
    [HideInInspector] public bool isPlayerMove = false;


    #endregion

    #region Singleton
    public static GameManager Instance
    {
        get
        {
            if(_initialized) return _instance;
            _initialized = true;

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("No Singleton");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void EndGame()
    {
        isEnd = true;
        StartCoroutine(PlayerMoveForward());
    }

    IEnumerator PlayerMoveForward()
    {
        yield return new WaitForSecondsRealtime(4f);
        isPlayerMove = true;
    }
}
