using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestToggleGroupDlg : MonoBehaviour
{
    [SerializeField] Toggle[] m_toggles = new Toggle[3];
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnClear = null;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_toggles[0].onValueChanged.AddListener(OnValueChanged_Apple);
        m_toggles[1].onValueChanged.AddListener(OnValueChanged_Pear);
        m_toggles[2].onValueChanged.AddListener(OnValueChanged_Orange);
    }

    void OnClicked_OK()
    {
        string str = "����� ������ ������ ";
        if (m_toggles[0].isOn) str += "<color=#FAA500>���</color> ";
        else if (m_toggles[1].isOn) str += "<color=#FAA500>��</color> ";
        else str += "<color=#FAA500>������</color> ";
        str += "�Դϴ�.";

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "result";
        for (int i = 0; i < m_toggles.Length; i++) m_toggles[i].isOn = false;
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
