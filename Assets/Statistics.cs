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

    private DateTime data1 = new DateTime(1000, 1, 1);
    private DateTime data2 = new DateTime(1000, 1, 1);
    private DateTime data3 = new DateTime(1000, 1, 1);
    private DateTime data4 = new DateTime(1000, 1, 1);
    private string file1;
    private string file2;
    private string file3;
    private string file4;
    private string Username;
    private string Name;
    private string Surname;
    private String[] Lines;
    private bool flag;
    private float ache1;
    private int cont1;
    private float ache2;
    private int cont2;
    private float ache3;
    private int cont3;
    private float ache4;
    private int cont4;
    private float survey1;
    private float survey2;
    private float survey3;
    private float survey4;
    private String[] LinesAche;
    private String[] LinesSurvey1;
    private String[] LinesSurvey2;
    private String[] LinesSurvey3;
    private String[] LinesSurvey4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PrintStatistics()
    {
        ache1 = 0;
        cont1 = 0;
        ache2 = 0;
        cont2 = 0;
        ache3 = 0;
        cont3 = 0;
        ache4 = 0;
        cont4 = 0;
        survey1 = 0;
        survey2 = 0;
        survey3 = 0;
        survey4 = 0;
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
                    if(File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) > data1){
                        data4 = data3;
                        data3 = data2;
                        data2 = data1;
                        data1 = File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 = file2;
                        file2 = file1;
                        file1 = "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) > data2)
                    {
                        data4 = data3;
                        data3 = data2;
                        data2 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 = file2;
                        file2 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) > data3)
                    {
                        data4 = data3;
                        data3 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 = file3;
                        file3 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name) > data4)
                    {
                        data4 =  File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name);
                        file4 =  "Assets/TextFile/" + Name + " " + Surname + "/" + Files[i].Name;
                    }
                }
                DirectoryInfo dAche = new DirectoryInfo("Assets/TextFile/" + Name + " " + Surname+" ValutationAche");
                FileInfo[] FilesAche = dAche.GetFiles("*.txt");
                for (int i = 0; i < FilesAche.Length; i++)
                {
                    LinesAche = System.IO.File.ReadAllLines("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name);
                    if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) >= data4.AddDays(-7) && File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) < data4)
                    {
                        ache4 = ache4 + float.Parse(LinesAche[0]);
                        cont4 = cont4 + 1;
                    }else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) >= data4 && File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) < data3)
                    {
                        ache3 = ache3 + float.Parse(LinesAche[0]);
                        cont3 = cont3 + 1;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) >= data3 && File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) < data2)
                    {
                        ache2 = ache2 + float.Parse(LinesAche[0]);
                        cont2 = cont2 + 1;
                    }
                    else if (File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) >= data2 && File.GetCreationTime("Assets/TextFile/" + Name + " " + Surname + " ValutationAche/" + FilesAche[i].Name) < data1)
                    {
                        ache1 = ache1 + float.Parse(LinesAche[0]);
                        cont1 = cont1 + 1;
                    }
                }
                if (Files.Length == 1)
                {
                    LinesSurvey1 = System.IO.File.ReadAllLines(file1);
                    for (int i = 0; i < LinesSurvey1.Length; i++)
                    {
                        survey1 = survey1 + float.Parse(LinesSurvey1[i]) / LinesSurvey1.Length;
                    }
                    ache1 = ache1 / cont1;
                    settimana2.SetActive(false);
                    textData2.gameObject.SetActive(false);
                    settimana3.SetActive(false);
                    textData3.gameObject.SetActive(false);
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                    survey1 = (10 - ache1) / 2 + survey1 * 5 / 3;
                    settimana1.GetComponent<RectTransform>().localPosition = new Vector3(settimana1.GetComponent<RectTransform>().localPosition.x, -400 + (survey1 - 10) * 20, settimana1.GetComponent<RectTransform>().localPosition.z);
                    settimana1.GetComponent<RectTransform>().localScale = new Vector3(100,400 + (survey1 - 10) * 40,0.01f);
                    textData1.text = data1.AddDays(-7).ToString("dd-MM") + "/" + Environment.NewLine + data1.ToString("dd-MM");
                }
                else if (Files.Length == 2)
                {
                    LinesSurvey1 = System.IO.File.ReadAllLines(file1);
                    LinesSurvey2 = System.IO.File.ReadAllLines(file2);
                    for (int i = 0; i < LinesSurvey1.Length; i++)
                    {
                        survey1 = survey1 + float.Parse(LinesSurvey1[i]) / LinesSurvey1.Length;
                        survey2 = survey2 + float.Parse(LinesSurvey2[i]) / LinesSurvey2.Length;
                    }
                    Debug.Log("survey2 "+survey2);
                    Debug.Log("ache2 "+ache2);
                    Debug.Log("cont2 " + cont2);
                    Debug.Log("survey1 " + survey1);
                    Debug.Log("ache1 " + ache1);
                    Debug.Log("cont1 " + cont1);
                    ache1 = ache1 / cont1;
                    ache2 = ache2 / cont2;
                    settimana3.SetActive(false);
                    textData3.gameObject.SetActive(false);
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                    survey1 = (10 - ache1) / 2 + survey1 * 5 / 3;
                    survey2 = (10 - ache2) / 2 + survey2 * 5 / 3;
                    settimana1.GetComponent<RectTransform>().localPosition = new Vector3(settimana1.GetComponent<RectTransform>().localPosition.x, -400 + (survey2 - 10) * 20, settimana1.GetComponent<RectTransform>().localPosition.z);
                    settimana1.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey2 - 10) * 40, 0.01f);
                    textData1.text = data2.AddDays(-7).ToString("dd-MM") + "/" + Environment.NewLine + data2.ToString("dd-MM");
                    settimana2.GetComponent<RectTransform>().localPosition = new Vector3(settimana2.GetComponent<RectTransform>().localPosition.x, -400 + (survey1 - 10) * 20, settimana2.GetComponent<RectTransform>().localPosition.z);
                    settimana2.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey1 - 10) * 40, 0.01f);
                    textData2.text = data2.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data1.ToString("dd-MM");
                }
                else if (Files.Length == 3)
                {
                    LinesSurvey1 = System.IO.File.ReadAllLines(file1);
                    LinesSurvey2 = System.IO.File.ReadAllLines(file2);
                    LinesSurvey3 = System.IO.File.ReadAllLines(file3);
                    for (int i = 0; i < LinesSurvey1.Length; i++)
                    {
                        survey1 = survey1 + float.Parse(LinesSurvey1[i]) / LinesSurvey1.Length;
                        survey2 = survey2 + float.Parse(LinesSurvey2[i]) / LinesSurvey2.Length;
                        survey3 = survey3 + float.Parse(LinesSurvey3[i]) / LinesSurvey3.Length;
                    }
                    ache1 = ache1 / cont1;
                    ache2 = ache2 / cont2;
                    ache3 = ache3 / cont3;
                    settimana4.SetActive(false);
                    textData4.gameObject.SetActive(false);
                    survey1 = (10 - ache1) / 2 + survey1 * 5 / 3;
                    survey2 = (10 - ache2) / 2 + survey2 * 5 / 3;
                    survey3 = (10 - ache3) / 2 + survey3 * 5 / 3;
                    settimana1.GetComponent<RectTransform>().localPosition = new Vector3(settimana1.GetComponent<RectTransform>().localPosition.x, -400 + (survey3 - 10) * 20, settimana1.GetComponent<RectTransform>().localPosition.z);
                    settimana1.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey3 - 10) * 40, 0.01f);
                    textData1.text = data3.AddDays(-7).ToString("dd-MM") + "/" + Environment.NewLine + data3.ToString("dd-MM");
                    settimana2.GetComponent<RectTransform>().localPosition = new Vector3(settimana2.GetComponent<RectTransform>().localPosition.x, -400 + (survey2 - 10) * 20, settimana2.GetComponent<RectTransform>().localPosition.z);
                    settimana2.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey2 - 10) * 40, 0.01f);
                    textData2.text = data3.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data2.ToString("dd-MM");
                    settimana3.GetComponent<RectTransform>().localPosition = new Vector3(settimana3.GetComponent<RectTransform>().localPosition.x, -400 + (survey1 - 10) * 20, settimana3.GetComponent<RectTransform>().localPosition.z);
                    settimana3.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey1 - 10) * 40, 0.01f);
                    textData3.text = data2.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data1.ToString("dd-MM");
                }
                else
                {
                    LinesSurvey1 = System.IO.File.ReadAllLines(file1);
                    LinesSurvey2 = System.IO.File.ReadAllLines(file2);
                    LinesSurvey3 = System.IO.File.ReadAllLines(file3);
                    LinesSurvey4 = System.IO.File.ReadAllLines(file4);
                    for (int i = 0; i < LinesSurvey1.Length; i++)
                    {
                        survey1 = survey1 + float.Parse(LinesSurvey1[i]) / LinesSurvey1.Length;
                        survey2 = survey2 + float.Parse(LinesSurvey2[i]) / LinesSurvey2.Length;
                        survey3 = survey3 + float.Parse(LinesSurvey3[i]) / LinesSurvey3.Length;
                        survey4 = survey4 + float.Parse(LinesSurvey4[i]) / LinesSurvey4.Length;
                    }
                    ache1 = ache1 / cont1;
                    ache2 = ache2 / cont2;
                    ache3 = ache3 / cont3;
                    ache4 = ache4 / cont4;
                    survey1 = (10 - ache1) / 2 + survey1 * 5 / 3;
                    survey2 = (10 - ache2) / 2 + survey2 * 5 / 3;
                    survey3 = (10 - ache3) / 2 + survey3 * 5 / 3;
                    survey4 = (10 - ache4) / 2 + survey4 * 5 / 3;
                    settimana1.GetComponent<RectTransform>().localPosition = new Vector3(settimana1.GetComponent<RectTransform>().localPosition.x, -450 + (survey4 - 10) * 20, settimana1.GetComponent<RectTransform>().localPosition.z);
                    settimana1.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey4 - 10) * 40, 0.01f);
                    textData1.text = data4.AddDays(-7).ToString("dd-MM") + "/" + Environment.NewLine + data4.ToString("dd-MM");
                    settimana2.GetComponent<RectTransform>().localPosition = new Vector3(settimana2.GetComponent<RectTransform>().localPosition.x, -450 + (survey3 - 10) * 20, settimana2.GetComponent<RectTransform>().localPosition.z);
                    settimana2.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey3 - 10) * 40, 0.01f);
                    textData2.text = data4.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data3.ToString("dd-MM");
                    settimana3.GetComponent<RectTransform>().localPosition = new Vector3(settimana3.GetComponent<RectTransform>().localPosition.x, -450 + (survey2 - 10) * 20, settimana3.GetComponent<RectTransform>().localPosition.z);
                    settimana3.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey2 - 10) * 40, 0.01f);
                    textData3.text = data3.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data2.ToString("dd-MM");
                    settimana4.GetComponent<RectTransform>().localPosition = new Vector3(settimana4.GetComponent<RectTransform>().localPosition.x, -450 + (survey1 - 10) * 20, settimana4.GetComponent<RectTransform>().localPosition.z);
                    settimana4.GetComponent<RectTransform>().localScale = new Vector3(100, 400 + (survey1 - 10) * 40, 0.01f);
                    textData4.text = data2.AddDays(1).ToString("dd-MM") + "/" + Environment.NewLine + data1.ToString("dd-MM");
                }
            }
        }
    }
}
