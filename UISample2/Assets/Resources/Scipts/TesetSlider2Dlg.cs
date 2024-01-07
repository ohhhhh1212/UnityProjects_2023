using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesetSlider2Dlg : MonoBehaviour
{
    [SerializeField] Slider m_sliderRed = null;
    [SerializeField] Slider m_sliderGreen = null;
    [SerializeField] Slider m_sliderBlue = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtR = null;
    [SerializeField] Text m_txtG = null;
    [SerializeField] Text m_txtB = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_sliderRed.onValueChanged.AddListener(OnValueChanged_Red);
        m_sliderGreen.onValueChanged.AddListener(OnValueChanged_Green);
        m_sliderBlue.onValueChanged.AddListener(OnValueChanged_Blue);
        m_btnOk.onClick.AddListener(OnCliced_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnCliced_Ok()
    {
        Color color = m_txtResult.color;
        m_txtResult.text = $"현재 색상값은 R : {(int)(color.r * 255)}, G : {(int)(color.g * 255)}, B : {(int)(color.b * 255)}입니다.";
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = string.Empty;
    }

    void OnValueChanged_Red(float f)
    {
        float col = f / 255;
        Color color = new Color(col, m_txtResult.color.g, m_txtResult.color.b, 1f);
        m_txtR.text = $"{(int)f}";
        m_txtResult.text = "현재 색상 값 입니다.";
        m_txtResult.color = color;
    }

    void OnValueChanged_Green(float f)
    {
        float col = f / 255;
        Color color = new Color(m_txtResult.color.r, col, m_txtResult.color.b, 1f);
        m_txtG.text = $"{(int)f}";
        m_txtResult.text = "현재 색상 값 입니다.";
        m_txtResult.color = color;
    }

    void OnValueChanged_Blue(float f)
    {
        float col = f / 255;
        Color color = new Color(m_txtResult.color.r, m_txtResult.color.g, col, 1f);
        m_txtB.text = $"{(int)f}";
        m_txtResult.text = "현재 색상 값 입니다.";
        m_txtResult.color = color;
    }
}
