using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score
{
    public string name = "";
    public int kor = 0;
    public int eng = 0;
    public int math = 0;

    public void Set(string s, int k, int e, int m)
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

    public float GetAverage()
    {
        return (float)GetTotal() / 3;
    }

    public int GetTotal()
    {
        return kor + eng + math;
    }
}

public class Test012Dlg : MonoBehaviour
{
    public InputField m_inputName = null;
    public InputField m_inputKor = null;
    public InputField m_inputEng = null;
    public InputField m_inputMath = null;
    public Text m_txtResult = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;

    Score score = new Score();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
    }

    void OnClicked_OK()
    {
        score.Set(m_inputName.text, int.Parse(m_inputKor.text), int.Parse(m_inputEng.text), int.Parse(m_inputMath.text));

        float avg = score.GetAverage();
        int tot = score.GetTotal();

        string res = string.Format("이름 : {0}\n국어={1}, 영어={2}, 수학={3}\n", score.name, score.kor, score.eng, score.math);
        res += string.Format("합계={0}, 평균={1:0.00}", tot, avg);
        m_txtResult.text = res;
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        score.Remove();
    }

}
