using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public GameObject name;
    public GameObject surname;
    public GameObject docName;

    private string Name;
    private string Surname;
    private string DocName;

    public GameObject username;
    public GameObject password;
    public GameObject login;
    public GameObject Exercise;
    public GameObject Login_canvas;
    public GameObject Logo;
    private string Username;
    private string Password;
    public String[] Lines;
    private string DecryptedPass;
    

    public GameObject displayName;
    public GameObject displayNameDoc;
    

    // Start is called before the first frame update

    public void LoginButton()
    {
        bool UN = false;
        bool PW = false;
        

        if (Username!= "")
        {
            if (System.IO.File.Exists(@"Assets/TextFile/"+Username+".txt"))
            {
                print("entro");
                UN = true;
                Lines = System.IO.File.ReadAllLines(@"Assets/TextFile/" + Username + ".txt");
            }
            else
            {
                
                Debug.LogWarning("Username is INVALID");
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
        }
        if (Password != "")
        {
            if (System.IO.File.Exists(@"Assets/TextFile/"+Username+".txt"))
            {

                int i = 1;
                foreach (char c in Lines[6])
                {
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPass += Decrypted.ToString();
                }
                if (Password == DecryptedPass)
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password Is Invalid");
                }
            }
            else
            {
                Debug.LogWarning("Password Is Invalid");
            }

        }
        else
        {
            Debug.LogWarning("Password Field Empty");
        }
        if (UN == true && PW == true)
        {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            name.GetComponent<InputField>().text = "";
            surname.GetComponent<InputField>().text = "";
            docName.GetComponent<InputField>().text = "";

            print("Login Successful");

            Login_canvas.SetActive(false);
            Logo.SetActive(false);
            Exercise.SetActive(true);

            Name = Lines[0];
            Surname = Lines[1];
            DocName = Lines[4];

            displayName.GetComponent<Text>().text = "Welcome " + Name + " " + Surname;
            displayNameDoc.GetComponent<Text>().text = "DOC. " + DocName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        login.GetComponent<Button>().interactable = false;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();

            }
        }
        
        
        if (Username!= "" && Password != "" )
        {

            login.GetComponent<Button>().interactable = true;
        }
        else
        {
            login.GetComponent<Button>().interactable = false;
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;




    }


}
