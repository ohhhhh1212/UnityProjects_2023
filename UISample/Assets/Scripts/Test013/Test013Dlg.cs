using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2
{
    public string name = "";
    public int kor = 0;
    public int eng = 0;
    public int math = 0;

    public Score2(string s, int k, int e, int m)
    {
        name = s;
        kor = k;
        eng = e;
        math = m;
    }

    public int tot
    {
        get { return kor + eng + math; }
    }

    public float avg
    {
        get { return (float)tot / 3; }
    }

    //public void Set(string s, int k, int e, int m)
    //{
    //    name = s;
    //    kor = k;
    //    eng = e;
    //    math = m;
    //}

    //public float GetAverage()
    //{
    //    return (float)GetTotal() / 3;
    //}

    //public int GetTotal()
    //{
    //    return kor + eng + math;
    //}
}

public class Test013Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtAdded = null;
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnCancel = null;
    [SerializeField] Button m_btnAdd = null;

    List<Score2> m_scorelist = new List<Score2>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_OK()
    {
        string str = "[己利包府]\n====================================\n";

        for (int i = 0; i < m_scorelist.Count; i++)
        {
            Score2 score = m_scorelist[i];
            str += string.Format("{0} : {1}, {2}, {3} 钦拌={4} 乞闭={5:0.0}\n", score.name, score.kor, score.eng, score.math, score.tot, score.avg);
        }

        m_txtResult.text = str;
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        m_txtAdded.text = string.Empty;
        m_scorelist.Clear();
    }

    void OnClicked_Add()
    {
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);
        Score2 score = new Score2(m_inputName.text, kor, eng, math);

        m_scorelist.Add(score);
        m_txtAdded.text += $"{score.name} : {kor}, {eng}, {math}\n";
    }


}
