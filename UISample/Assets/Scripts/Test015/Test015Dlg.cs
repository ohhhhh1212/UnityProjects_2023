using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score4
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

    public Score4(string s, int k, int e, int m)
    {
        name = s;
        kor = k;
        eng = e;
        math = m;
    }

}

public class Test015Dlg : MonoBehaviour
{
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnCancel = null;
    [SerializeField] Button m_btnFile = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtAdded = null;

    List<Score4> score4 = new List<Score4>();

    void Start()
    {
        Init();
        m_txtAdded.text = string.Empty;
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnFile.onClick.AddListener(OnClicked_File);
    }

    void OnClicked_OK()
    {
        string str = "[성적관리]\n==================================\n";
        int totkor = 0;
        int toteng = 0;
        int totmath = 0;

        score4.Sort((a, b) => a.tot > b.tot ? -1 : 1);

        for (int i = 0; i < score4.Count; i++)
        {
            Score4 score = score4[i];
            str += string.Format("{0}등 : {1} {2} {3} {4} :합계={5} 평균={6:0.0}\n", i + 1, score.name, score.kor, score.eng, score.math, score.tot, score.avg);

            totkor += score.kor;
            toteng += score.eng;
            totmath += score.math;
        }

        str += "==================================\n";
        str += string.Format("과목별 합계 -- 국어:({0}, {1:0.0}), 영어:({2}, {3:0.0}), 수학:({4}, {5:0.0})", totkor, Average(totkor), toteng, Average(toteng), totmath, Average(totmath));
        m_txtResult.text = str;
    }

    float Average(int i)
    {
        return (float)i / score4.Count;
    }

    void OnClicked_Cancel()
    {
        m_txtAdded.text = string.Empty;
        score4.Clear();
        m_txtResult.text = "Result";
    }
    
    void OnClicked_Add()
    {
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);
        Score4 score = new Score4(m_inputName.text, kor, eng, math);

        if(CheckNum(kor) || CheckNum(eng) || CheckNum(math))
        {
            print("범위를 벗어났습니다");
            return;
        }

        score4.Add(score);

        string str = string.Format("{0}: {1}, {2}, {3}\n", score.name, kor, eng, math);
        m_txtAdded.text += str;
    }

    void OnClicked_File()
    {

    }

    bool CheckNum(int i)
    {
        if (i > 100 || i < 0)
            return true;
        else
            return false;
    }
    

}
