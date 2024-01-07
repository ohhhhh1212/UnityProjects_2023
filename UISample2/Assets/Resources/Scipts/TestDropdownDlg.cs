using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDropdownDlg : MonoBehaviour
{
    [SerializeField] Dropdown m_dropdown = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnReset = null;

    List<string> m_city = new List<string>();
    int m_idx = 0;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < m_dropdown.options.Count; i++)
            m_city.Add(m_dropdown.options[i].text);

        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
        m_dropdown.onValueChanged.AddListener(OnValueChanged_Drop);
    }

    void OnClicked_Ok()
    {
        string str = $"당신이 이동할 도시는 {m_city[m_idx]}입니다.";
        m_txtResult.text = str;
    }

    void OnClicked_Reset()
    {
        m_txtResult.text = "result";
        m_dropdown.value = 0;
    }

    void OnValueChanged_Drop(int i)
    {
        string str = $"{i} : {m_city[i]}";
        m_txtResult.text = str;
        m_idx = i;
    }
}
