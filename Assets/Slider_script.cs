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
        Lines = System.IO.File.ReadAllLines(@"Assets/TextFile/" + Username + ".txt");
        Name = Lines[0];
        Surname = Lines[1];
        if (!Directory.Exists("Assets/TextFile/" + Name + " " + Surname + " ValutationAche"))
        {
            string guid = AssetDatabase.CreateFolder("Assets/TextFile", Name + " " + Surname + " ValutationAche");
        }
        System.IO.File.WriteAllText(@"Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + Date + ".txt", value_ache.ToString());
    }

    
}
