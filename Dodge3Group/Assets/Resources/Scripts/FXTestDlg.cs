using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXTestDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnPlay = null;
    [SerializeField] Button m_btnStop= null;
    [SerializeField] FXTest m_FxTest = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnPlay.onClick.AddListener(OnClicked_Play);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }

    void OnClicked_Play()
    {
        m_FxTest.PlayEffect();
        m_txtResult.text = "Playing...";
    }

    void OnClicked_Stop()
    {
        m_FxTest.StopEffect();

        m_txtResult.text = "Stop";
    }

}
