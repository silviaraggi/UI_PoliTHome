using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;
    public GameObject register_button;
    public GameObject Register_canvas;
    public GameObject Login_canvas;

    public GameObject name;
    public GameObject surname;

    public GameObject name_doctor;
    public GameObject email_doctor;

    
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string Name;
    private string Surname;
    private string Doc_name;
    private string Doc_email;
    private string form;
    private bool EmailValid = false;
    private string[] Characters = {"a", "b" ,"c" ,"d", "e" ,"f" ,"g" ,"h" ,"i" ,"j", "k", "l", "m" ,"n","o"," p","q", "r", "s", "t", "u" ,"v", "w", "x","y","z",
        "A","B", "C","D", "E","F","G","H"," I", "J" ,"K" ,"L", "M", "N", "O", "P","Q", "R", "S", "T","U", "V","W", "X", "Y" ,"Z","1","2","3","4","5"," 6"," 7"," 8","9"," 0", "@", ".", "_","-"};



    // Start is called before the first frame update
    void Start()
    {

    }
    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        bool NM = false;
        bool SN = false;
        bool DC = false;
        bool DCEM = false;

        if (Name != "")
        {
            NM = true;
        }
        else
        {
            Debug.LogWarning("Name Empty");
        }
        if (Surname != "")
        {
            SN = true;
        }
        else
        {
            Debug.LogWarning("Surname Empty");
        }
        if (Doc_name != "")
        {
            DC = true;
        }
        else
        {
            Debug.LogWarning("Name Empty");
        }
        if (Username != "")
        {
            if (!System.IO.File.Exists(@"\$PATH:/Assets/TextFile/" + Username + ".txt"))
            {
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username Taken");
            }
        }
        else
        {
            Debug.LogWarning("Username field Empty");
        }
        if (Email != "")
        {
            EmailValidation();
            {
                if (EmailValid)
                {
                    if (Email.Contains("@"))
                    {
                        if (Email.Contains("."))
                        {
                            EM = true;
                        }
                        else
                        {
                            Debug.LogWarning("Email is Incorrect");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Email is Incorrect");
                    }
                }
                else
                {
                    Debug.LogWarning("Email is Incorrect");
                }
            }
        }
        else
        {
            Debug.LogWarning("Email Field Empty");
        }
        if (Doc_email != "")
        {
            EmailValidation();
            {
                if (EmailValid)
                {
                    if (Email.Contains("@"))
                    {
                        if (Email.Contains("."))
                        {
                            DCEM = true;
                        }
                        else
                        {
                            Debug.LogWarning("Email is Incorrect");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Email is Incorrect");
                    }
                }
                else
                {
                    Debug.LogWarning("Email is Incorrect");
                }
            }
        }
        else
        {
            Debug.LogWarning("Email Field Empty");
        }

        if (Password != "")
            {
                if (Password.Length > 5)
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password Must Be atleast 6 Character long");
                }
            }
            else
            {
                Debug.LogWarning("Password Field Empty");
            }
            if (ConfPassword != "")
            {
                if (ConfPassword == Password)
                {
                    CPW = true;
                }
                else
                {
                    Debug.LogWarning("Passwords Don't Match");
                }
            }
            else
            {
                Debug.LogWarning("Confirm Password Field Empty");
            }


            if (UN == true && EM == true && PW == true && CPW == true && DC==true && DCEM==true && NM==true && SN==true)
            {
                bool Clear = true;
                int i = 1;
                foreach (char c in Password)
                {
                    if (Clear)
                    {
                        Password = "";
                        Clear = false;
                    }
                    i++;
                    char Encrypted = (char)(c * i);
                    Password += Encrypted.ToString();
                }
                form = (Name + Environment.NewLine + Surname + Environment.NewLine + Username + Environment.NewLine+ Email +Environment.NewLine + Doc_name + Environment.NewLine + Doc_email + Environment.NewLine+ Password);
                System.IO.File.WriteAllText(@"Assets/TextFile/" + Username + ".txt", form);
                username.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                confPassword.GetComponent<InputField>().text = "";
                name.GetComponent<InputField>().text= "";
                surname.GetComponent<InputField>().text="";
                name_doctor.GetComponent<InputField>().text="";
                email_doctor.GetComponent<InputField>().text="";
                print("Registration Complete");

                Register_canvas.SetActive(false);
                Login_canvas.SetActive(true);
                
            
               
            }

        }
        // Update is called once per frame
        void Update()
        {
        register_button.GetComponent<Button>().interactable = false;

        if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (name.GetComponent<InputField>().isFocused)
                {
                    surname.GetComponent<InputField>().Select();
                }
                if (surname.GetComponent<InputField>().isFocused)
                {
                    username.GetComponent<InputField>().Select();
                }
                if (username.GetComponent<InputField>().isFocused)
                {
                    email.GetComponent<InputField>().Select();
                }
                if (email.GetComponent<InputField>().isFocused)
                {
                    password.GetComponent<InputField>().Select();
                }
                if (password.GetComponent<InputField>().isFocused)
                {
                    confPassword.GetComponent<InputField>().Select();
                }
                if (confPassword.GetComponent<InputField>().isFocused)
                {
                    name_doctor.GetComponent<InputField>().Select();
                }
                if (name_doctor.GetComponent<InputField>().isFocused)
                {
                    email_doctor.GetComponent<InputField>().Select();
                }


        }
            
            if (Password != " " && Email != "" && Password != "" && ConfPassword != "" && Name !="" && Surname!="" && Doc_name!="" && Doc_email!="")
            {

                register_button.GetComponent<Button>().interactable = true;

            }
            

            Username = username.GetComponent<InputField>().text;
            Email = email.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
            ConfPassword = confPassword.GetComponent<InputField>().text;
            Name = name.GetComponent<InputField>().text;
            Surname = surname.GetComponent<InputField>().text;
            Doc_name = name_doctor.GetComponent<InputField>().text;
            Doc_email = email_doctor.GetComponent<InputField>().text;

    }
        void EmailValidation()
        {
            bool SW = false;
            bool EW = false;
            for (int i = 0; i < Characters.Length; i++)
            {
                if (Email.StartsWith(Characters[i]))
                {
                    SW = true;
                }
            }
            for (int i = 0; i < Characters.Length; i++)
            {
                if (Email.EndsWith(Characters[i]))
                {
                    EW = true;
                }
            }
            if (SW == true && EW == true)
            {
                EmailValid = true;
            }
        }
    }

   

