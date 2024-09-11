using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Panel;
    public void ClickPause()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
    }

    public void ClickClose()
    {
        Time.timeScale = 1.0f;
        Panel.SetActive(false);
    }

}
