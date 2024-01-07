using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    [SerializeField] Text m_txtStage = null;
    [SerializeField] Text m_txtScore = null;
    [SerializeField] Text m_txtTotScore = null;
    [SerializeField] Text m_txtClear = null;
    [SerializeField] Text m_txtLose = null;
    [SerializeField] Button m_btnExit = null;
    [SerializeField] Button m_btnRestart = null;
    [SerializeField] Button m_btnNext = null;

 

    public void Init()
    {
        m_btnExit.onClick.AddListener(OnClicked_Exit);
        m_btnRestart.onClick.AddListener(OnClicked_Restart);
        m_btnNext.onClick.AddListener(OnClicked_Next);
        gameObject.SetActive(false);

        m_txtLose.gameObject.SetActive(false);
        m_txtClear.gameObject.SetActive(false);
        m_btnNext.gameObject.SetActive(false);
    }

    public void SetResultUI(bool isClear)
    {
        gameObject.SetActive(true);

        m_txtStage.text = $"Stage : {GameMgr.Inst.curStage}";
        m_txtScore.text = $"Score : {GameMgr.Inst.curScore}";
        m_txtTotScore.text = $"Total Score : {GameMgr.Inst.GetAccumScore()}";

        if (isClear)
        {
            m_txtClear.gameObject.SetActive(true);
            m_btnNext.gameObject.SetActive(true);
        }
        else
            m_txtLose.gameObject.SetActive(true);
    }

    void OnClicked_Exit()
    {
        SceneManager.LoadScene("Title");
    }

    void OnClicked_Restart()
    {
        GameMgr.Inst.battleFSM.SetReadyState();
    }

    void OnClicked_Next()
    {
        GameMgr.Inst.curStage += 1;
        OnClicked_Restart();
    }


}
