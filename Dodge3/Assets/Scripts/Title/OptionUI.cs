using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnCancel = null;
    [SerializeField] Toggle m_tglBGM = null;
    [SerializeField] Toggle m_tglSFX = null;
    [SerializeField] Text m_txtBGM = null;
    [SerializeField] Text m_txtSFX = null;
    [SerializeField] TitleUI m_TitleUI = null;


    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_tglBGM.onValueChanged.AddListener(OnValueChanged_Bgm);
        m_tglSFX.onValueChanged.AddListener(OnValueChanged_Sfx);
        gameObject.SetActive(false);

        m_tglBGM.isOn = PlayerPrefs.GetInt("BGM") == 1 ? true : false;
        m_tglSFX.isOn = PlayerPrefs.GetInt("SFX") == 1 ? true : false;
    }
    
    void OnClicked_Ok()
    {
        int bgm = m_tglBGM.isOn ? 1 : 0;
        int sfx = m_tglSFX.isOn ? 1 : 0;

        PlayerPrefs.SetInt("BGM", bgm);
        PlayerPrefs.SetInt("SFX", sfx);

        m_TitleUI.Check_Toggle();

        gameObject.SetActive(false);
    }

    void OnClicked_Cancel()
    {
        gameObject.SetActive(false);
    }

    void OnValueChanged_Bgm(bool b)
    {
        if (b) m_txtBGM.text = "BGM On";
        else m_txtBGM.text = "BGM Off";
    }

    void OnValueChanged_Sfx(bool b)
    {
        if (b) m_txtSFX.text = "SFX On";
        else m_txtSFX.text = "SFX Off";
    }
}
