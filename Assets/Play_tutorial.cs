﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_tutorial : MonoBehaviour
{
    public GameObject text;
    public Animator text_image;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play_tutorial_text()
    {
        text.SetActive(true);
        text_image.SetBool("isOpen", true);
    }

    public void Close_tutorial_text()
    {
        text_image.SetBool("isOpen", false);
    }
}
