using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Statistics : MonoBehaviour
{
    public GameObject username;
    public Login login;
    public GameObject settimana1;
    public GameObject settimana2;
    public GameObject settimana3;
    public GameObject settimana4;
    public Text textData1;
    public Text textData2;
    public Text textData3;
    public Text textData4;

    private DateTime data1 = new DateTime(3000, 1, 1);
    private DateTime data2 = new DateTime(3000, 1, 1);
    private DateTime data3 = new DateTime(3000, 1, 1);
    private DateTime data4 = new DateTime(3000, 1, 1);
    private string file1;
    private string file2;
    private string file3;
    private string file4;
    private string Username;
    private string Name;
    private string Surname;
    private String[] Lines;
    private bool flag;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PrintStatistics();
    }

    public void PrintStatistics()
    {
        if (login.access is true)
        {
            Username = username.GetComponent<InputField>().text;
            Lines = System.IO.File.ReadAllLines(@"Assets/TextFile/" + Username + ".txt");
            Name = Lines[0];
            Surname = Lines[1];

            if (Directory.Exists("Assets/TextFile/" + Name + " " + Surname))
            {
                DirectoryInfo d = new DirectoryInfo("Assets/TextFile/" + Name + " " + Surname);
                FileInfo[] Files = d.GetFiles("*.txt");
                for (int i = 0; i < Files.Length; i++)
                {
                    if(File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) < data1){
                        data4 = data3;
                        data3 = data2;
                        data2 = data1;
                        data1 = File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 = file2;
                        file2 = file1;
                        file1 = "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) < data2)
                    {
                        data4 = data3;
                        data3 = data2;
                        data2 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 = file2;
                        file2 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) < data3)
                    {
                        data4 = data3;
                        data3 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) < data4)
                    {
                        data4 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    Debug.Log(file1);
                    Debug.Log(data1);
                }
                if (Files.Length == 1)
                {
                    settimana2.SetActive(false);
                    textData2.gameObject.SetActive(false);
                    settimana3.SetActive(false);
                    textData3.gameObject.SetActive(false);
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                } else if (Files.Length == 2)
                {
                    settimana3.SetActive(false);
                    textData3.gameObject.SetActive(false);
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                } else if (Files.Length == 3)
                {
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                }
            }
        }
    }
}
