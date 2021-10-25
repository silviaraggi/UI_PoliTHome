using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{

    public Slider sliderUI;
    public Text textSliderValue;
    private int value_ache;

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

    
}
