using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calcul1 : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnNum1 = null;
    [SerializeField] Button m_btnNum2 = null;
    [SerializeField] Button m_btnPlus = null;
    [SerializeField] Button m_btnResult = null;
    [SerializeField] Button m_btnClear = null;

    string m_nums = "";
    List<int> m_listnums = new List<int>();
    bool m_isplus = false;
    bool m_isresult = false;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnNum1.onClick.AddListener(OnClicked_Num1);
        m_btnNum2.onClick.AddListener(OnClicked_Num2);
        m_btnPlus.onClick.AddListener(OnClicked_Plus);
        m_btnResult.onClick.AddListener(OnClicked_Result);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Num1()
    {
        SetNum("1");
    }

    void OnClicked_Num2()
    {
        SetNum("2");
    }

    void OnClicked_Plus()
    {
        if (m_isplus)
            return;

        if (m_isresult)
        {
            m_listnums.Clear();
            m_listnums.Add(int.Parse(m_txtResult.text));
        }

        m_listnums.Add(int.Parse(m_txtResult.text));
        m_isplus = true;
        m_nums = "0";
    }

    void OnClicked_Result()
    {
        if (m_isresult)
            return;

        if(!m_isplus)
            m_listnums.Add(int.Parse(m_txtResult.text));

        int tot = 0;
        for (int i = 0; i < m_listnums.Count; i++)
            tot += m_listnums[i];

        m_txtResult.text = $"{tot}";
        m_isresult = true;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "0";
        m_nums = string.Empty;
        m_listnums.Clear();
        m_isplus = false;
        m_isresult = false;
    }

    void SetNum(string s)
    {
        if (m_isplus)
        {
            m_isplus = false;
            m_nums = string.Empty;
        }

        if (m_isresult)
        {
            m_isresult = false;
            m_nums = string.Empty;
            m_listnums.Clear();
        }

        m_nums += s;
        m_txtResult.text = m_nums;
    }

}
