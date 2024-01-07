using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score
{
    public static int score = 0;

    public Score(int s)
    {
        score += s;
    }
}

public class StaticTestDlg : MonoBehaviour
{
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnReset = null;
    [SerializeField] Text m_txtResult = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
    }

    void OnClicked_OK()
    {
        GetTot();
    }

    void OnClicked_Reset()
    {
        Score.score = 0;
        m_txtResult.text = "0";
    }

    void GetTot()
    {
        Score k = new Score(90);
        Score p = new Score(90);
        Score m = new Score(95);

        m_txtResult.text = Score.score.ToString();
    }
}
