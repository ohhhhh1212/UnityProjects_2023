using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test05Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtCount = null;
    [SerializeField] Button btnStart = null;
    [SerializeField] Button btnStop = null;
    [SerializeField] Button btnReset = null;
    float t = 0f;
    bool m_isCount = false;
    string str = "";

    private void Start()
    {
        Init();
    }

    void Update()
    {
        if (m_isCount)
        {
            t += Time.deltaTime;

            int min = (int)(t / 60);
            int sec = (int)(t % 60);

            float ms = t - (min * 60 + sec);

            str = string.Format("{0:00}:{1:00}:{2:00}", min, sec, ms*100);
            m_txtCount.text = str;
        }
    }

    void Init()
    {
        btnStart.onClick.AddListener(OnClicked_Start);
        btnStop.onClick.AddListener(OnClicked_Stop);
        btnReset.onClick.AddListener(OnClicked_Reset);
    }

    void OnClicked_Start()
    {
        m_isCount = true;
    }

    void OnClicked_Stop()
    {
        m_isCount = false;
    }

    void OnClicked_Reset()
    {
        m_isCount = false;
        t = 0f;
        m_txtCount.text = "00:00:00";
    }
}
