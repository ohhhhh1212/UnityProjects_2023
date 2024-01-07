using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScrollbarDlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_scroll.onValueChanged.AddListener(OnValueChanged);
    }

    void OnClicked_OK()
    {
        string str = $"현재 진행된 값은 {m_scroll.value} 입니다.";
        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = string.Empty;
    }

    void OnValueChanged(float f)
    {
        m_txtResult.text = $"{f}";
    }
}
