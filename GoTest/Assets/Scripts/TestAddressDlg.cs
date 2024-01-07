using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Info
{
    public string m_name = "";
    public string m_hp = "";
    public string m_city = "";

    public Info(string n, string h, string c)
    {
        m_name = n;
        m_hp = h;
        m_city = c;
    }
}


public class TestAddressDlg : MonoBehaviour
{
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputHp = null;
    [SerializeField] InputField m_inputCity = null;
    [SerializeField] InputField m_inputSearchName = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnSearch = null;
    [SerializeField] Button m_btnPrintAll = null;
    [SerializeField] Button m_btnReset = null;
    [SerializeField] Button m_btnSaveFile = null;
    [SerializeField] Button m_btnLoadFile = null;

    List<Info> m_listInfos = new List<Info>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnSearch.onClick.AddListener(OnClicked_Serch);
        m_btnPrintAll.onClick.AddListener(OnClicked_Print);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
        m_btnSaveFile.onClick.AddListener(OnClicked_SaveFile);
        m_btnLoadFile.onClick.AddListener(OnClicked_LoadFile);
    }

    void OnClicked_Add()
    {
        Info info = new Info(m_inputName.text, m_inputHp.text, m_inputCity.text);
        m_listInfos.Add(info);
        m_listInfos.Sort((x, y) => { return x.m_name.CompareTo(y.m_name); });

        m_txtResult.text = string.Empty;
        string str = $"이름 : {info.m_name}\n전화 : {info.m_hp}\n도시 : {info.m_city}";
        m_txtResult.text = str;

        m_inputName.text = string.Empty;
        m_inputHp.text = string.Empty;
        m_inputCity.text = string.Empty;

    }

    void OnClicked_Serch()
    {
        string name = m_inputSearchName.text;
        string str = "---------------------------------\n순번 이름    전화         도시\n---------------------------------\n";
        int cnt = 1;

        for (int i = 0; i < m_listInfos.Count; i++)
        {
            if (m_listInfos[i].m_name.Contains(name))
            {
                Info info = m_listInfos[i];
                str += $"{cnt}  {info.m_name}  {info.m_hp}  {info.m_city}\n";
                str += "---------------------------------\n";
                cnt++;
            }
        }

        m_txtResult.text = str;
    }

    void OnClicked_Print()
    {
        string str = "---------------------------------\n순번 이름    전화         도시\n---------------------------------\n";

        for (int i = 0; i < m_listInfos.Count; i++)
        {
            Info info = m_listInfos[i];
            str += $"{i + 1}  {info.m_name}  {info.m_hp}  {info.m_city}\n";
            str += "---------------------------------\n";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Reset()
    {
        m_listInfos.Clear();
        m_txtResult.text = "result";
        m_inputName.text = string.Empty;
        m_inputHp.text = string.Empty;
        m_inputCity.text = string.Empty;
        m_inputSearchName.text = string.Empty;
    }

    void OnClicked_SaveFile()
    {
        SaveFile();
    }

    void OnClicked_LoadFile()
    {
        LoadFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Infos.txt");

        sw.WriteLine(m_listInfos.Count);
        for (int i = 0; i < m_listInfos.Count; i++)
        {
            sw.WriteLine(m_listInfos[i].m_name);
            sw.WriteLine(m_listInfos[i].m_hp);
            sw.WriteLine(m_listInfos[i].m_city);
        }

        sw.Close();
    }

    void LoadFile()
    {
        StreamReader sr = new StreamReader("Infos.txt");
        m_listInfos.Clear();

        int idx = int.Parse(sr.ReadLine());
        if (idx == 0)
        {
            print("불러올 내용이 없습니다");
            return;
        }

        for (int i = 0; i < idx; i++)
        {
            string name = sr.ReadLine();
            string hp = sr.ReadLine();
            string city = sr.ReadLine();
            Info score = new Info(name, hp, city);
            m_listInfos.Add(score);
        }

        OnClicked_Print();

        sr.Close();
    }

}
