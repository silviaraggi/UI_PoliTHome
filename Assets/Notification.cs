using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine.UI;

using UnityEngine;
using System.IO;

public class Notification : MonoBehaviour
{

    public GameObject green_notifica;
    public GameObject green_cloud;
    public GameObject blue_cloud;
    public GameObject survey_button;
    public GameObject panel;
    public GameObject username;
    public Login login;

    public Animator notifica_verde;
    public Animator notifica_blue;

    private int type_notifica=0;

    private string Name;
    private string Surname;
    private string Username;
    private String[] Lines;

    private string today;
    private string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
    DateTime now = DateTime.Now;
    private bool week = false;


    void Update()
    {
        if (login.access is true)
        {
            
            Username = username.GetComponent<InputField>().text;
            Lines = System.IO.File.ReadAllLines(@"Assets/TextFile/" + Username + ".txt");
            Name = Lines[0];
            Surname = Lines[1];

            
            foreach (string files in Directory.GetFiles(@"Assets/TextFile/" + Name + " " + Surname, ".txt"))
            {
                
                DateTime contents = File.GetCreationTime(files);
                print(contents.Day.ToString());
                TimeSpan Diff_dates = contents.Subtract(now);
                print(Diff_dates.ToString());
                if (Diff_dates.Days == 7)
                {
                    panel.SetActive(false);
                    survey_button.GetComponent<Button>().interactable = true;
                    type_notifica = 2;
                    week = true;
                }

            }

            if (currentDate != today && week == false)
            {
                type_notifica = 1;
                today = currentDate;

            }
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
            week = false;
        }


        
        
    }

    
}
