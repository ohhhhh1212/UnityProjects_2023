using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Score5
{
    public string name = "";
    public int kor = 0;
    public int eng = 0;
    public int math = 0;

    public int tot
    {
        get { return kor + eng + math; }
    }

    public float avg
    {
        get { return (float)tot / 3; }
    }

    public Score5(string s, int k, int e, int m)
    {
        name = s;
        kor = k;
        eng = e;
        math = m;
    }
}

public class Test016Dlg : MonoBehaviour
{
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_bntCancel = null;
    [SerializeField] Button m_btnSaveFile = null;
    [SerializeField] Button m_btnLoadFile = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtAdded = null;

    List<Score5> m_score5 = new List<Score5>();

    void Start()
    {
        Init();
        m_txtAdded.text = string.Empty;
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_bntCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnSaveFile.onClick.AddListener(OnClicked_SaveFile);
        m_btnLoadFile.onClick.AddListener(OnClicked_LoadFile);
    }

    void OnClicked_Add()
    {
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);
        Score5 score = new Score5(m_inputName.text, kor, eng, math);

        m_score5.Add(score);
        string str = string.Format("{0}: {1}, {2}, {3}\n", score.name, kor, eng, math);
        m_txtAdded.text += str;
    }

    void OnClicked_OK()
    {
        string str = "Name Kor Eng Mat  < 종합 >\n============================\n";
        string name = "";
        string kor = "";
        string eng = "";
        string math = "";
        string avg = "";

        m_score5.Sort((a, b) => a.tot < b.tot ? 1 : -1);

        for (int i = 0; i < m_score5.Count; i++)
        {
            Score5 score = m_score5[i];
            name = score.name;
            kor = GetRank(score.kor);
            eng = GetRank(score.eng);
            math = GetRank(score.math);
            avg = GetRank((int)score.avg);

            str += string.Format("{0}  {1} {2} {3}  <{4}>\n", name, kor, eng, math, avg);
        }

        m_txtResult.text = str;
    }

    void OnClicked_Cancel()
    {
        m_score5.Clear();
        m_txtAdded.text = string.Empty;
        m_txtResult.text = "Result";
    }

    void OnClicked_SaveFile()
    {
        SaveFile();
    }

    void OnClicked_LoadFile()
    {
        LoadFile();

        string str = string.Empty;
        for (int i = 0; i < m_score5.Count; i++)
        {
            string name = m_score5[i].name;
            int kor = m_score5[i].kor;
            int eng = m_score5[i].eng;
            int math = m_score5[i].math;
            str += string.Format("{0}: {1}, {2}, {3}\n", name, kor, eng, math);
        }

        m_txtAdded.text = str;
    }

    string GetRank(int i)
    {
        if (i > 100 || i < 0)
        {
            print("범위를 벗어남");
            return string.Empty;
        }
        else if (i < 101 && i > 89) return "A";
        else if (i > 79) return "B";
        else if (i > 69) return "C";
        else if (i > 59) return "D";
        else return "F";
    }

    void SaveFile()
    {
        if(m_score5.Count == 0)
        {
            print("한 개 이상 일때만 저장가능");
            return;
        }

        StreamWriter sw = new StreamWriter("Score.txt");

        sw.WriteLine(m_score5.Count);
        for (int i = 0; i < m_score5.Count; i++)
        {
            sw.WriteLine(m_score5[i].name);
            sw.WriteLine(m_score5[i].kor);
            sw.WriteLine(m_score5[i].eng);
            sw.WriteLine(m_score5[i].math);
        }

        sw.Close();
    }

    void LoadFile()
    {
        StreamReader sr = new StreamReader("Score.txt");
        m_score5.Clear();

        int idx = int.Parse(sr.ReadLine());
        if(idx == 0)
        {
            print("불러올 내용이 없습니다");
            return;
        }

        for (int i = 0; i < idx; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score5 score = new Score5(name, kor, eng, math);
            m_score5.Add(score);
        }
        
        sr.Close();
    }
}
