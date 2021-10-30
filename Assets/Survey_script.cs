using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

using System.Timers;
using UnityEditor;

public class Survey_script : MonoBehaviour
{
    public GameObject cappotto;
    public GameObject dormire;
    public GameObject porta_dietro;
    public GameObject lavarsi;
    public GameObject pettinarsi;
    public GameObject lanciare;
    public GameObject raggiungere_scaffale;
    public GameObject sollevare;
    public GameObject sport;
    public GameObject lavorare;
    public GameObject username;
    public GameObject send_button;

    private string Cappotto;
    private string Dormire;
    private string Porta_dietro;
    private string Lavarsi;
    private string Pettinarsi;
    private string Lanciare;
    private string Raggiungere_scaffale;
    private string Sollevare;
    private string Sport;
    private string Lavorare;
    private string Username;
    private string Name;
    private string Surname;

    private string form;
    private String[] Lines;
    public DateTime datetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cappotto = cappotto.GetComponent<InputField>().text;
        Dormire = dormire.GetComponent<InputField>().text;
        Porta_dietro = porta_dietro.GetComponent<InputField>().text;
        Lavarsi = lavarsi.GetComponent<InputField>().text;
        Pettinarsi = pettinarsi.GetComponent<InputField>().text;
        Lanciare = lanciare.GetComponent<InputField>().text;
        Raggiungere_scaffale = raggiungere_scaffale.GetComponent<InputField>().text;
        Sollevare = sollevare.GetComponent<InputField>().text;
        Sport = sport.GetComponent<InputField>().text;
        Lavorare = lavorare.GetComponent<InputField>().text;


        if (Cappotto != "" && Dormire != ""&& Porta_dietro != ""&& Lavarsi != "" && Pettinarsi != "" && Lanciare != "" && Raggiungere_scaffale != ""&& Sollevare != ""&& Sport!="" && Lavorare != "")
        {
            send_button.GetComponent<Button>().interactable = true;

        }

       
    }

    public void Save_and_send()
    {
        string Date = DateTime.Now.ToString("dd-MM-yyyy");
        

        Username = username.GetComponent<InputField>().text;
        bool C = false;
        bool D = false;
        bool PD = false;
        bool L = false;
        bool P = false;
        bool LA = false;
        bool R = false;
        bool S = false;
        bool SPRT = false;
        bool LVR = false;

        if (Cappotto != "")
        {
            C = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Dormire != "")
        {
            D = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Porta_dietro != "")
        {
            PD = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Lavarsi != "")
        {
            L = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Pettinarsi != "")
        {
            P = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Lanciare != "")
        {
            LA = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Raggiungere_scaffale != "")
        {
            R = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Sollevare != "")
        {
            S = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Sport != "")
        {
            SPRT = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }
        if (Lavorare != "")
        {
            LVR = true;
        }
        else
        {
            Debug.LogWarning("Input Empty");
        }

        if (C == true && D == true && PD == true && L == true && P == true && LA == true && R == true && S == true && SPRT == true && LVR == true)
        {
            string file = Application.dataPath;
            string[] pathArray = file.Split('/');
            file = "";
            for (int i = 0; i < pathArray.Length - 1; i++)
            {
                file += pathArray[i] + "/";
            }
            form = (Cappotto + Environment.NewLine + Dormire + Environment.NewLine + Porta_dietro + Environment.NewLine + Lavarsi + Environment.NewLine + Pettinarsi + Environment.NewLine + Lanciare + Environment.NewLine + Raggiungere_scaffale + Environment.NewLine + Sollevare + Environment.NewLine +Sport + Environment.NewLine + Lavorare + Environment.NewLine + Date);
            Lines = System.IO.File.ReadAllLines(file + Username + ".txt");
            Name = Lines[0];
            Surname = Lines[1];
            Directory.CreateDirectory(file+ Name + " " + Surname);
            System.IO.File.WriteAllText(file+Name+" "+Surname+"/" + Date + ".txt", form);
        }

        cappotto.GetComponent<InputField>().text = "";
        dormire.GetComponent<InputField>().text = "";
        porta_dietro.GetComponent<InputField>().text = "";
        lavarsi.GetComponent<InputField>().text = "";
        pettinarsi.GetComponent<InputField>().text = "";
        lanciare.GetComponent<InputField>().text = "";
        raggiungere_scaffale.GetComponent<InputField>().text = "";
        sollevare.GetComponent<InputField>().text = "";
        sport.GetComponent<InputField>().text = "";
        lavorare.GetComponent<InputField>().text = "";
    }
}
