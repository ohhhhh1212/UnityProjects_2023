using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSliderDlg : MonoBehaviour
{
    [SerializeField] Slider m_slider = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;


    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_slider.onValueChanged.AddListener(OnValueChanged);
    }

    void OnClicked_Ok()
    {
        string str = $"현재 진행된 값은 {(int)m_slider.value} 입니다.";
        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = string.Empty;
    }

    void OnValueChanged(float f)
    {
        m_txtResult.text = $"{(int)f}";
    }
}
