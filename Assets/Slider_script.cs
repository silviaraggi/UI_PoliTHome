using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Slider_script : MonoBehaviour
{

    public Slider sliderUI;
    public Text textSliderValue;
    private float value_ache;
    public GameObject username;
    private string Username;
    private string Name;
    private string Surname;
    private String[] Lines;

    void Start()
    {
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = "Soglia del dolore " + sliderUI.value;
        textSliderValue.text = sliderMessage;
        print(sliderUI.value);
       
    }

    public void SaveAche()
    {
        value_ache = sliderUI.value;
        string Date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
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
        if (!Directory.Exists(file + Name + " " + Surname + " ValutationAche"))
        {
            Directory.CreateDirectory(file+ Name + " " + Surname + " ValutationAche");
        }
        System.IO.File.WriteAllText(file + Name + " " + Surname + " ValutationAche/" + Date + ".txt", value_ache.ToString());
    }

    
}
