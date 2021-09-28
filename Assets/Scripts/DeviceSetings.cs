using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeviceSetings : MonoBehaviour
{
    public static bool mobile = false;

    private void Start()
    {
        Screen.SetResolution(1080, 1920 , true);
    }

    public void SelectMobile()
    {
        mobile = true;
        SceneManager.LoadScene(1);
    }

    public void SelectPC()
    {
        mobile = false;
        SceneManager.LoadScene(1);
    }
    
}
