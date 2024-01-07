using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    public StartDlg startDlg = null;
    public GameDlg gameDlg = null;
    public ResultDlg resultDlg = null;


    private void Update()
    {
        if (GameMgr.Inst.battleFSM.IsGameState())
            SetTimer();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        SetReady();
    }

    public IEnumerator Co_StartCount()
    {
        SetTimer();
        gameDlg.m_txtCount.gameObject.SetActive(true);
        SetDlgActive("start", false);
        SetDlgActive("game", true);
        SetDlgActive("result", false);

        for (int i = 3; i > 0; i--)
        {
            gameDlg.m_txtCount.text = $"{i}";
            yield return new WaitForSeconds(1f);
        }

        gameDlg.m_txtCount.text = "Start!";
        yield return new WaitForSeconds(1f);
        gameDlg.m_txtCount.gameObject.SetActive(false);

        gameDlg.m_txtTimer.gameObject.SetActive(true);

        GameMgr.Inst.battleFSM.SetGameState();
    }

    public void SetDlgActive(string s, bool b)
    {
        switch (s)
        {
            case "start":
                {
                    startDlg.gameObject.SetActive(b);
                    break;
                }
            case "game":
                {
                    gameDlg.gameObject.SetActive(b);
                    break;
                }
            case "result":
                {
                    resultDlg.gameObject.SetActive(b);
                    break;
                }
        }
    }

    public void SetResult()
    {
        SetDlgActive("game", false);
        SetDlgActive("result", true);

        resultDlg.m_txtResultTime.text = string.Format("{0:00} : {1:00}", GameMgr.Inst.min, GameMgr.Inst.sec);
    }

    public void SetReady()
    {
        SetDlgActive("start", true);
        SetDlgActive("game", false);
        SetDlgActive("result", false);
    }

    void SetTimer()
    {
        gameDlg.m_txtTimer.text = string.Format("Time {0:00} : {1:00}", GameMgr.Inst.min, GameMgr.Inst.sec);
    }

}
