using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMaterialDlg : MonoBehaviour
{
    [SerializeField] MeshRenderer m_sphere = null;
    [SerializeField] Slider m_sldRed = null;
    [SerializeField] Slider m_sldBlue = null;
    [SerializeField] Slider m_sldGreen = null;
    [SerializeField] Slider m_sldAlpha = null;
    [SerializeField] InputField m_inputRed = null;
    [SerializeField] InputField m_inputBlue = null;
    [SerializeField] InputField m_inputGreen = null;
    [SerializeField] InputField m_inputAlpha = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_sldRed.onValueChanged.AddListener(OnValueChanged_Red);
        m_sldBlue.onValueChanged.AddListener(OnValueChanged_Blue);
        m_sldGreen.onValueChanged.AddListener(OnValueChanged_Green);
        m_sldAlpha.onValueChanged.AddListener(OnValueChanged_Alpha);
    }

    void OnValueChanged_Red(float f)
    {
        Color color = m_sphere.material.color;
        color.r = f / 255;

        m_sphere.material.color = color;

        m_inputRed.text = $"{f}";
    }

    void OnValueChanged_Blue(float f)
    {
        Color color = m_sphere.material.color;
        color.b = f / 255;

        m_sphere.material.color = color;

        m_inputBlue.text = $"{f}";
    }

    void OnValueChanged_Green(float f)
    {
        Color color = m_sphere.material.color;
        color.g = f / 255;

        m_sphere.material.color = color;

        m_inputGreen.text = $"{f}";
    }

    void OnValueChanged_Alpha(float f)
    {
        Color color = m_sphere.material.color;
        color.a = f / 255;

        m_sphere.material.color = color;

        m_inputAlpha.text = $"{f}";
    }


}
