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
    public GameObject survey_button1;
    public GameObject survey_button2;
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
    private DateTime old= new DateTime(2000, 1, 1);
    private bool week = false;
    private bool firstLogin = false;


    void Update()
    {
        if (login.access is true && firstLogin==false)
        {
            
            Username = username.GetComponent<InputField>().text;
            string file = Application.dataPath;
            string[] pathArray = file.Split('/');
            file = "";
            for (int i = 0; i < pathArray.Length - 1; i++)
            {
                file += pathArray[i] + "/";
            }
            Lines = System.IO.File.ReadAllLines(file + Username + ".txt");
            Name = Lines[0];
            Surname = Lines[1];

            
            if(!Directory.Exists(file + Name + " " + Surname))
            {
                old = File.GetCreationTime(file + Username + ".txt");               
                if ((now-old).Days >= 7)
                {
                    type_notifica = 2;
                    panel.SetActive(false);
                    week = true;
                }
                //Debug.Log(type_notifica);
            } else
            {
                foreach (string files in Directory.GetFiles(file + Name + " " + Surname))
                {
                    if (File.GetCreationTime(files) > old)
                        old = File.GetCreationTime(files);
                }
                //Debug.Log(old);
                if ((now - old).Days >= 7)
                {
                    type_notifica = 2;
                    panel.SetActive(false);
                    week = true;
                }
                //Debug.Log(type_notifica);
            }
            /*foreach (string files in Directory.GetFiles(@"Assets/TextFile/" + Name + " " + Surname, ".txt"))
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

            }*/

            if (currentDate != today && week == false)
            {
                type_notifica = 1;
                today = currentDate;

            }
            OpenNotifica();
            firstLogin = true;
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
            survey_button1.GetComponent<Button>().interactable = true;
            survey_button2.GetComponent<Button>().interactable = true;

        }
    }
    public void CloseNotifica()
    {
        if (type_notifica == 1)
        {
            notifica_verde.SetBool("isOpen", false);
            green_notifica.SetActive(false);
            /*green_cloud.SetActive(false);*/
            type_notifica = 0;

        }
        else if(type_notifica == 2)
        {
            notifica_blue.SetBool("isOpen", false);
            green_notifica.SetActive(false);
            /*blue_cloud.SetActive(false);*/
            type_notifica = 0;
            week = false;
        }


        
        
    }

    
}
