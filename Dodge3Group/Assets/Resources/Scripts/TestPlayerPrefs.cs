using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerPrefs : MonoBehaviour
{
    [SerializeField] Toggle m_tglBg = null;
    [SerializeField] Toggle m_tglEffect = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Text m_txtResult = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnSave.onClick.AddListener(Onclicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void Onclicked_Save()
    {
        int bg = m_tglBg.isOn ? 1 : 0;
        int effect = m_tglEffect.isOn ? 1 : 0;

        PlayerPrefs.SetInt("Bg", bg);
        PlayerPrefs.SetInt("Effect", effect);

        m_txtResult.text = "저장 되었습니다.";
    }

    void OnClicked_Load()
    {
        int bg = PlayerPrefs.GetInt("Bg");
        int effect = PlayerPrefs.GetInt("Effect");

        m_tglBg.isOn = bg == 1;
        m_tglEffect.isOn = effect == 1;

        m_txtResult.text = "불러와 졌습니다.";
    }

    void OnClicked_Clear()
    {
        m_tglBg.isOn = false;
        m_tglEffect.isOn = false;
        m_txtResult.text = "초기화 되었습니다.";
    }
}
