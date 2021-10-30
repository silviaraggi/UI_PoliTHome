using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System.Linq;

public class Doctor : MonoBehaviour
{

    public GameObject name_doctor;
    public Dropdown patient;
    public GameObject questionario;

    private string Name_doctor;
    private string Patient;

    public GameObject panel_empty;
    public GameObject search_button;
    private String[] Lines;
    private String[] New_lines;
    private string Nome;
    private string Cognome;
    private string Nome_cartella;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;

    private List<string> my_dropOption = new List<string> { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Name_doctor = name_doctor.GetComponent<InputField>().text;
        if (Name_doctor != "")
        {
            panel_empty.SetActive(false);
            search_button.GetComponent<Button>().interactable = true;
            
        }
        else
        {
            panel_empty.SetActive(true);
            Debug.LogWarning("Name is Empty");
        }



    }

    public void Add_patient()
    {
        string file = Application.dataPath;
        string[] pathArray = file.Split('/');
        file = "";
        for (int i = 0; i < pathArray.Length - 1; i++)
        {
            file += pathArray[i] + "/";
        }

        print(file);

        DirectoryInfo d = new DirectoryInfo(file);
        
        FileInfo[] Files = d.GetFiles("*.txt");
        print(Files.Length);
        for(int i=0; i<Files.Length; i++)
        {
           
            Lines = System.IO.File.ReadAllLines(Files[i].Name);
            if (Name_doctor == Lines[4])
            {
                print(Lines[0]);
            
              
                my_dropOption.Add(Lines[0]+" "+Lines[1]);
            }
            else
            {
                Debug.LogWarning("No match");
            }
        }
        
       patient.ClearOptions();
       patient.AddOptions(my_dropOption);
        questionario.SetActive(true);

    }

    public void Visualize_survey()
    {

        Nome_cartella = patient.options[patient.value].text;
        print("Nome cartella"+Nome_cartella);

        string file = Application.dataPath;
        string[] pathArray = file.Split('/');
        file = "";
        for (int i = 0; i < pathArray.Length - 1; i++)
        {
            file += pathArray[i] + "/";
        }

        print(file);

        DirectoryInfo d = new DirectoryInfo(file);

        FileInfo newestFile = GetNewestFile(new DirectoryInfo(d+"/"+Nome_cartella));
        print("NewestFile "+newestFile);
        print("NOME FILE " + newestFile.Name);
   
        New_lines = System.IO.File.ReadAllLines(d+"/"+Nome_cartella+"/"+newestFile.Name);
        
        print("Lines" + New_lines);

        text1.text = New_lines[0];
        text2.text = New_lines[1];
        text3.text = New_lines[2];
        text4.text = New_lines[3];
        text5.text = New_lines[4];
        text6.text = New_lines[5];
        text7.text = New_lines[6];
        text8.text = New_lines[7];
        text9.text = New_lines[8];
        text10.text = New_lines[9];

        string io = Lines[1];
        print("ecco il numero:"+io);

    }
    public static FileInfo GetNewestFile(DirectoryInfo directory)
    {
        return directory.GetFiles()
            .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
            .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
            .FirstOrDefault();
    }
}
