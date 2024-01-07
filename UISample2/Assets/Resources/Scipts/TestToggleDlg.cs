using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestToggleDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnClear = null;

    [SerializeField] Toggle[] m_toggleOn = new Toggle[3];

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_toggleOn[0].onValueChanged.AddListener(OnValueChanged_Apple);
        m_toggleOn[1].onValueChanged.AddListener(OnValueChanged_Pear);
        m_toggleOn[2].onValueChanged.AddListener(OnValueChanged_Orange);
    }

    void OnClicked_OK()
    {
        string str = "����� ������ ������ ";
        if (m_toggleOn[0].isOn) str += "<color=#FAA500>���</color> ";
        if (m_toggleOn[1].isOn) str += "<color=#FAA500>��</color> ";
        if (m_toggleOn[2].isOn) str += "<color=#FAA500>������</color> ";
        str += "�Դϴ�.";

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "result";
        for (int i = 0; i < m_toggleOn.Length; i++) m_toggleOn[i].isOn = false;
    }

    void OnValueChanged_Apple(bool b)
    {
        if (b) m_txtResult.text = "���";
        else m_txtResult.text = string.Empty;
    }

    void OnValueChanged_Pear(bool b)
    {
        if (b) m_txtResult.text = "��";
        else m_txtResult.text = string.Empty;
    }

    void OnValueChanged_Orange(bool b)
    {
        if (b) m_txtResult.text = "������";
        else m_txtResult.text = string.Empty;
    }
}
