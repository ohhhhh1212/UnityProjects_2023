using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnOption = null;
    [SerializeField] GameObject m_OptionUI = null;
    [SerializeField] AudioSource m_bgm = null;
    [SerializeField] AudioSource m_click = null;
    bool isprevBgm = true;
    bool m_Sfx = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_Sfx)
            m_click.Play();
    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnOption.onClick.AddListener(OnClicked_Option);
        Check_Toggle();
    }

    void OnClicked_Start()
    {

        SceneManager.LoadScene("Game");
    }

    void OnClicked_Option()
    {
        m_OptionUI.SetActive(true);
    }

    public void Check_Toggle()
    {
        bool bgm = PlayerPrefs.GetInt("BGM") == 1 ? true : false;
        bool sfx = PlayerPrefs.GetInt("SFX") == 1 ? true : false;

        if (!bgm)
        {
            m_bgm.Stop();
            isprevBgm = false;
        }
        else if(!isprevBgm)
        {
            m_bgm.Play();
            isprevBgm = true;
        }

        m_Sfx = sfx;
    }
}
