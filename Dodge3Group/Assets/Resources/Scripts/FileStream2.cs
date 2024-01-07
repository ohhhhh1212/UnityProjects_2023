using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Info
{
    public int num;
    public string name;
    public int score;

    public Info(int no, string s, int sc)
    {
        num = no;
        name = s;
        score = sc;
    }
}

public class FileStream2 : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] InputField m_ipfNum = null;
    [SerializeField] InputField m_ipfName = null;
    [SerializeField] InputField m_ipfScore = null;

    List<Info> m_Infos = new List<Info>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Add()
    {
        int num = int.Parse(m_ipfNum.text);
        string name = m_ipfName.text;
        int score = int.Parse(m_ipfScore.text);

        Info info = new Info(num, name, score);

        m_Infos.Add(info);

        PrintList();

        m_ipfNum.text = string.Empty;
        m_ipfName.text = string.Empty;
        m_ipfScore.text = string.Empty;
    }

    void OnClicked_Save()
    {
        FileStream fs = new FileStream("save02.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(m_Infos.Count);

        for (int i = 0; i < m_Infos.Count; i++)
        {
            bw.Write(m_Infos[i].num);
            bw.Write(m_Infos[i].name);
            bw.Write(m_Infos[i].score);
        }

        fs.Close();
        bw.Close();

        m_txtResult.text = "저장 되었습니다.";
    }

    void OnClicked_Load()
    {
        try
        {
            m_Infos.Clear();

            FileStream fs = new FileStream("save02.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int n = br.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                int num = br.ReadInt32();
                string name = br.ReadString();
                int score = br.ReadInt32();
                Info info = new Info(num, name, score);

                m_Infos.Add(info);
            }

            fs.Close();
            br.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }

        PrintList();
    }

    void OnClicked_Clear()
    {
        m_ipfNum.text = string.Empty;
        m_ipfName.text = string.Empty;
        m_ipfScore.text = string.Empty;
        m_txtResult.text = "초기화 되었습니다.";
    }

    void PrintList()
    {
        string str = "";

        for (int i = 0; i < m_Infos.Count; i++)
        {
            str += $"{m_Infos[i].num}, {m_Infos[i].name}, {m_Infos[i].score}\n";
        }

        m_txtResult.text = str;
    }
}
