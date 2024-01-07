using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScrollbar2Dlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    bool isCount = false;
    float t = 0f;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (isCount && m_scroll.value <= 1f)
        {
            t += Time.deltaTime;
            if(t >= 1f)
            {
                m_scroll.value += 0.05f;
                t = 0f;
            }
        }
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_scroll.onValueChanged.AddListener(OnValueChanged_Scroll);
    }

    void OnClicked_Start()
    {
        isCount = true;
    }

    void OnClicked_Stop()
    {
        isCount = false;
    }

    void OnValueChanged_Scroll(float f)
    {
        Color col = m_txtResult.color;
        col.a = f;
        m_txtResult.color = col;
        m_txtResult.text = string.Format("{0:0.00}", f);
    }
}
