using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine.UI;

using UnityEngine;

public class Notification : MonoBehaviour
{

    public GameObject green_notifica;
    public GameObject green_cloud;
    public GameObject blue_cloud;
    public GameObject survey_button;
    public GameObject panel;

    public Animator notifica_verde;
    public Animator notifica_blue;

    private int type_notifica=0;

    DateTime today;
    DateTime currentday = DateTime.Now;

    private int week = 0;

    void Update()
    {
       

        if (currentday!=today)
        {
            type_notifica = 1;
            today = currentday;
            week += 1;
        }

        if (week==7)
        {
            panel.SetActive(false);
            survey_button.GetComponent<Button>().interactable = true;
            type_notifica = 2;
        }
    }

    public void OpenNotifica()
    {
        if (type_notifica == 1)
        {
            green_cloud.SetActive(true);
            notifica_verde.SetBool("isOpen", true);
        }else if (type_notifica == 2)
        {
            blue_cloud.SetActive(true);
            notifica_blue.SetBool("isOpen", true);
            week = 0;
        }
    }
    public void CloseNotifica()
    {
        if (type_notifica == 1)
        {
            notifica_verde.SetBool("isOpen", false);
            green_notifica.SetActive(false);
            green_cloud.SetActive(false);
            type_notifica = 0;

        }
        else if(type_notifica == 2)
        {
            notifica_blue.SetBool("isOpen", false);
            green_notifica.SetActive(false);
            blue_cloud.SetActive(false);
            type_notifica = 0;
        }


        
        
    }

    
}
