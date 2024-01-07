using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDropdown2 : MonoBehaviour
{
    [SerializeField] Dropdown m_dropdown = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnReset = null;

    string[] m_cityArr = new string[6] { "인천", "대전", "대구", "광주", "울산", "부산" };


    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localPosition = new Vector2(0f, -720f);
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localPosition = new Vector2(0f, 720f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localPosition = new Vector2(1280f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localPosition = new Vector2(-1280f, 0f);
        }

        if (transform.localPosition.y < 0f)
            transform.localPosition = new Vector3(0f, transform.localPosition.y + (1f * Time.deltaTime), 0f);
        if (transform.localPosition.y > 0f)
            transform.localPosition = new Vector3(0f, transform.localPosition.y - (1f * Time.deltaTime), 0f);
        if (transform.localPosition.x < 0f)
            transform.localPosition = new Vector3(0f, transform.localPosition.x + (1f * Time.deltaTime), 0f);
        if (transform.localPosition.y < 0f)
            transform.localPosition = new Vector3(0f, transform.localPosition.x - (1f * Time.deltaTime), 0f);

    }

    void Init()
    {
        SettingDropdown();
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
        m_dropdown.onValueChanged.AddListener(OnValueChanged_Drop);
    }

    void OnClicked_Ok()
    {
        string str = $"당신이 이동할 도시는 {m_dropdown.options[m_dropdown.value].text}입니다.";
        m_txtResult.text = str;
    }

    void OnClicked_Reset()
    {
        m_txtResult.text = "result";
        m_dropdown.value = 0;
    }

    void OnValueChanged_Drop(int i)
    {
        m_txtResult.text = $"{i} : {m_dropdown.options[i].text}";
    }

    void SettingDropdown()
    {
        for (int i = 0; i < m_cityArr.Length; i++)
        {
            Dropdown.OptionData drop = new Dropdown.OptionData(m_cityArr[i]);
            m_dropdown.options.Add(drop);
        }
    }

    void PanelMove()
    {
        while (transform.localPosition.y < 0f)
            transform.localPosition = new Vector3(0f, transform.localPosition.y + Time.deltaTime, 0f);
    }
}
