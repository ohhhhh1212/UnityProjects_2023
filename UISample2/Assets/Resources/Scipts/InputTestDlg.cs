using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTestDlg : MonoBehaviour
{
    [SerializeField] InputField m_inputName = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnClear  = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_OK()
    {
        string name = m_inputName.text;
        string str = $"당신의 이름은 <color=#FAA500> {name} </color> 입니다";

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_inputName.text = string.Empty;
        m_txtResult.text = string.Empty;
    }
}
