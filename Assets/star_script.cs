using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star_script : MonoBehaviour
{
    public Animator star_animator;
    public GameObject send_button;
    public Toggle star1;
    public Toggle star2;
    public Toggle star3;
    public Toggle star4;
    public Toggle star5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        send_button.GetComponent<Button>().interactable = false;
        if (star1.GetComponent<Toggle>().isOn == true)
        {
            star1.GetComponent<Toggle>().interactable = false;
            star2.GetComponent<Toggle>().interactable = true;
            send_button.GetComponent<Button>().interactable = true;
            if (star2.GetComponent<Toggle>().isOn == false)
            {
                star1.GetComponent<Toggle>().interactable = true;
            }
               
        }
        if(star2.GetComponent<Toggle>().isOn == true)
        {
            star2.GetComponent<Toggle>().interactable = false;
            star3.GetComponent<Toggle>().interactable = true;
            if (star3.GetComponent<Toggle>().isOn == false)
            {
                star2.GetComponent<Toggle>().interactable = true;
            }
        }
        if (star3.GetComponent<Toggle>().isOn == true)
        {
            star3.GetComponent<Toggle>().interactable = false;
            star4.GetComponent<Toggle>().interactable = true;
            if (star4.GetComponent<Toggle>().isOn == false)
            {
                star3.GetComponent<Toggle>().interactable = true;
            }
        }
        if (star4.GetComponent<Toggle>().isOn == true)
        {
            star4.GetComponent<Toggle>().interactable = false;
            star5.GetComponent<Toggle>().interactable = true;
            if (star5.GetComponent<Toggle>().isOn == false)
            {
                star4.GetComponent<Toggle>().interactable = true;
            }
        }

        if (star1.GetComponent<Toggle>().isOn == false)
        {
            star1.GetComponent<Toggle>().interactable = true;
            send_button.GetComponent<Button>().interactable = false;
            star2.GetComponent<Toggle>().interactable = false;
        }
        if (star2.GetComponent<Toggle>().isOn == false)
        {
            star2.GetComponent<Toggle>().interactable = true;
            star3.GetComponent<Toggle>().interactable = false;
        }
        if (star3.GetComponent<Toggle>().isOn == false)
        {
            star3.GetComponent<Toggle>().interactable = true;
            star4.GetComponent<Toggle>().interactable = false;
        }
        if (star4.GetComponent<Toggle>().isOn == false)
        {
            star4.GetComponent<Toggle>().interactable = true;
            star5.GetComponent<Toggle>().interactable = false;
        }
    }



    public void Open()
    {
        star_animator.SetBool("isStar", true);
    }

    public void Send()
    {
        star_animator.SetBool("isStar", false);
    }
}
