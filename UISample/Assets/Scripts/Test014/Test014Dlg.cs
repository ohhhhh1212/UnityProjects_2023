using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score3
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

    public Score3(string s, int k, int e, int m)
    {
        name = s;
        kor = k;
        eng = e;
        math = m;
    }

    public void Remove()
    {
        name = "";
        kor = 0;
        eng = 0;
        math = 0;
}
}

public class Test014Dlg : MonoBehaviour
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

    List<Score3> score3 = new List<Score3>();

    void Start()
    {
        Init();
        m_txtAdded.text = string.Empty;
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_OK()
    {
        string str = "[성적 관리]\n============================================\n";
        int totkor = 0;
        int toteng = 0;
        int totmath = 0;

        score3.Sort((a, b) => a.tot < b.tot ? 1 : -1);

        for (int i = 0; i < score3.Count; i++)
        {
            Score3 score = score3[i];
            str += string.Format("{0}: {1}, {2}, {3} 합계={4} 평균={5:0.0}\n", score.name, score.kor, score.eng, score.math, score.tot, score.avg);
            totkor += score.kor;
            toteng += score.eng;
            totmath += score.math;
        }

        str += "============================================\n";
        str += string.Format("과목별 합계 -- 국어:({0}, {1:0.0}), 영어:({2}, {3:0.0}), 수학:({4}, {5:0.0})", totkor, Average(totkor), toteng, Average(toteng), totmath, Average(totmath));

        m_txtResult.text = str;
    }

    float Average(int i)
    {
        return (float)i / score3.Count;
    }


    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        m_txtAdded.text = string.Empty;
        score3.Clear();
    }

    void OnClicked_Add()
    {
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);
        Score3 score = new Score3(m_inputName.text, kor, eng, math);

        score3.Add(score);
        m_txtAdded.text += $"{m_inputName.text}: {kor}, {eng}, {math}\n";
    }


}
