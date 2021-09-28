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
        // set reso to be what i would like it to be for this game
        Screen.SetResolution(1080, 1920 , true);
    }
        // lets player select what device they are on then loads to main menu
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
