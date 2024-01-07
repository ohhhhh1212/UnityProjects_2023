using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour
{
    [SerializeField] Slider m_sldHp = null;
    [SerializeField] Slider m_sldTime = null;
    [SerializeField] Text m_txtHp = null;
    [SerializeField] Text m_txtTime = null;
    [SerializeField] Text m_txtStage = null;
    [SerializeField] Text m_txtLifeTime = null;

    float time = 0f;
    float keepTime = 0f;


    private void Update()
    {
        if (!GameMgr.Inst.battleFSM.IsGameState())
            return;

        Timer();
    }


    public void Init()
    {
        keepTime = GameMgr.Inst.gameInfo.m_KeepTime;
        time = 0f;

        m_txtHp.text = $"{GameMgr.Inst.gameInfo.m_PlayerHp}";
        m_txtTime.text = $"{(int)keepTime}";
        m_txtStage.text = $"{GameMgr.Inst.curStage}";

        m_sldHp.maxValue = GameMgr.Inst.gameInfo.m_PlayerHp;
        m_sldTime.maxValue = keepTime;
        m_sldHp.value = GameMgr.Inst.gameInfo.m_PlayerHp;
        m_sldTime.value = keepTime;
    }

    void Timer()
    {
        if(time >= GameMgr.Inst.gameInfo.m_KeepTime)
        {
            GameMgr.Inst.battleFSM.SetResultState();
        }

        time += Time.deltaTime;
        m_txtLifeTime.text = string.Format("{0:00}:{1:00}", (int)time / 60, (int)time % 60);
        m_txtTime.text = string.Format("{0}", (int)keepTime - (int)time);

        m_sldTime.value = keepTime - time;
    }

    public void SetHP()
    {
        m_sldHp.value = GameMgr.Inst.gameInfo.m_PlayerHp;

        if(GameMgr.Inst.gameInfo.m_PlayerHp <= 0)
            m_txtHp.text = "0";
        else
            m_txtHp.text = $"{GameMgr.Inst.gameInfo.m_PlayerHp}";
    }


}
