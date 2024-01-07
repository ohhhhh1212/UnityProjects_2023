using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Button m_btnItem = null;
    public Image m_image = null;
    [SerializeField] Text m_txtid = null;
    [SerializeField] Text m_txtname = null;
    [SerializeField] Text m_txtkor = null;
    [SerializeField] Text m_txteng = null;
    [SerializeField] Text m_txtmath = null;
    [SerializeField] Text m_txttot = null;
    [SerializeField] Text m_txtavg = null;

    public string m_id = "";
    public string m_name = "";
    public int m_kor = 0;
    public int m_eng = 0;
    public int m_math = 0;
    public int tot
    {
        get { return m_kor + m_eng + m_math; }
    }
    public float avg
    {
        get { return (float)tot / 3f; }
    }

    public void Init(string id, string name, int kor, int eng, int math)
    {
        m_id = id;
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;

        m_txtid.text = m_id;
        m_txtname.text = m_name;
        m_txtkor.text = $"{m_kor}";
        m_txteng.text = $"{m_eng}";
        m_txtmath.text = $"{m_math}";
        m_txttot.text = $"{tot}";
        m_txtavg.text = string.Format("{0:0.00}", avg);
    }

}
