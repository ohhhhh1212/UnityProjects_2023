using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextSaveDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    bool b = true;
    int i = 50;
    float f = 3.567f;
    string s = "안녕하세요";

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

    }

    void OnClicked_Save()
    {
        StreamWriter sw = new StreamWriter("test01.txt");

        sw.WriteLine(b);
        sw.WriteLine(i);
        sw.WriteLine(f);
        sw.WriteLine(s);

        sw.Close();

        m_txtResult.text = "저장되었습니다.";
    }

    void OnClicked_Load()
    {
        try
        {
            StreamReader sr = new StreamReader("test01.txt");

            bool m_b = bool.Parse(sr.ReadLine());
            int m_i = int.Parse(sr.ReadLine());
            float m_f = float.Parse(sr.ReadLine());
            string m_s = sr.ReadLine();

            sr.Close();

            m_txtResult.text = $"{m_b}\n{m_i}\n{m_f}\n{m_s}";
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "초기화 되었습니다.";
    }

}
