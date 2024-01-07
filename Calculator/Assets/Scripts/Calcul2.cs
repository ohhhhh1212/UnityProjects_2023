using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calcul2 : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtExpression = null;
    [SerializeField] Button[] m_btnNums = null;
    [SerializeField] Button[] m_btnSigns = null;
    [SerializeField] Button m_btnPoint = null;
    [SerializeField] Button m_btnResult = null;
    [SerializeField] Button m_btnClear = null;

    string m_nums = string.Empty;
    List<float> m_listnums = new List<float>();
    List<int> m_listsigns = new List<int>();
    bool m_isprevsign = false;
    bool m_isresult = false;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < m_btnNums.Length; i++)
        {
            int idx = i;
            m_btnNums[i].onClick.AddListener(() => OnClicked_Num(idx));
        }

        for (int i = 0; i < m_btnSigns.Length; i++)
        {
            int idx = i;
            m_btnSigns[i].onClick.AddListener(() => OnClicked_Sign(idx));
        }

        m_txtExpression.text = string.Empty;
        m_btnPoint.onClick.AddListener(OnClicked_Point);
        m_btnResult.onClick.AddListener(OnClicked_Result);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Num(int idx)
    {
        SetNum($"{idx}");
    }

    void OnClicked_Sign(int i)
    {
        if (m_isprevsign)
        {
            if(m_listsigns[m_listsigns.Count - 1] != i)
            {
                m_listsigns[m_listsigns.Count - 1] = i;
                m_txtExpression.text = string.Empty;
                SetExpressionText(0);
            }

            return;
        }

        if (m_isresult)
        {
            m_nums = m_txtResult.text;
            m_isresult = false;
        }

        m_listnums.Add(float.Parse(m_txtResult.text));
        m_listsigns.Add(i);
        m_isprevsign = true;
        m_nums = "0";
        SetExpressionText(0);
    }

    void OnClicked_Point()
    {
        m_nums += ".";
        m_txtResult.text = m_nums;
    }

    void OnClicked_Result()
    {
        if (m_isresult) return;

        if (!m_isprevsign)
            m_listnums.Add(float.Parse(m_txtResult.text));

        float tot = CalResult();

        SetExpressionText(1);
        m_txtResult.text = $"{tot}";
        m_listnums.Clear();
        m_listsigns.Clear();
        m_isresult = true;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "0";
        m_nums = string.Empty;
        m_listnums.Clear();
        m_listsigns.Clear();
        m_isresult = false;
        m_isprevsign = false;
        m_txtExpression.text = string.Empty;
    }

    void SetNum(string s)
    {
        if (m_isprevsign)
        {
            m_isprevsign = false;
            m_nums = string.Empty;
        }

        if (m_isresult)
        {
            m_isresult = false;
            m_nums = string.Empty;
            m_txtExpression.text = string.Empty;
            m_listnums.Clear();
            m_listsigns.Clear();
        }

        m_nums += s;
        m_txtResult.text = m_nums;
    }

    float CalResult()
    {
        float tot = 0;
        tot += m_listnums[0];
        int num;
        for (int i = 1; i < m_listnums.Count; i++)
        {
            num = m_listsigns[i - 1];

            if(num == 0) tot += m_listnums[i];
            else if(num == 1) tot -= m_listnums[i];
            else if(num == 2) tot *= m_listnums[i];
            else if(num == 3) tot /= m_listnums[i];
        }

        return tot;
    }

    string CheckSign(int idx)
    {
        if (idx == 0) return "+";
        else if (idx == 1) return "-";
        else if (idx == 2) return "X";
        else if (idx == 3) return "¡À";

        return null;
    }

    void SetExpressionText(int i)
    {
        if(i == 0)
        {
            string str = string.Empty;
            for (int j = 0; j < m_listnums.Count; j++)
            {
                string sign = CheckSign(m_listsigns[j]);
                str += $"{m_listnums[j]} {sign} ";
            }

            m_txtExpression.text = str;
        }
        else if(i == 1)
        {
            if (!m_isprevsign)
                m_txtExpression.text += $"{m_listnums[m_listnums.Count - 1]}";

            m_txtExpression.text += " = ";
        }
    }
}
