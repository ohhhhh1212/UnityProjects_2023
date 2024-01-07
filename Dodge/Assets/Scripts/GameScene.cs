using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] HudUI m_HudUI = null;
    [SerializeField] GameUI m_GameUI = null;
    [SerializeField] Transform m_Bullets = null;

    void Awake()
    {
        GameMgr.Inst.battleFSM.Initialize(OnEnter_Ready, OnEnter_Wave, OnEnter_Game, OnEnter_Result);
        Init();
    }

    void Init()
    {
        ClearBullets();
        m_GameUI.Init();
        GameMgr.Inst.Init();
    }

    void OnEnter_Ready()
    {
        m_HudUI.SetReady();
        Init();
    }

    void OnEnter_Wave()
    {
        Init();
        StartCoroutine(m_HudUI.Co_StartCount());
    }

    void OnEnter_Game()
    {
        for (int i = 0; i < m_GameUI.m_turrets.Length; i++)
        {
            m_GameUI.m_turrets[i].StartShot();
        }
    }

    void OnEnter_Result()
    {
        for (int i = 0; i < m_GameUI.m_turrets.Length; i++)
        {
            m_GameUI.m_turrets[i].StopShot();
        }

        m_HudUI.SetResult();
    }
    private void Update()
    {
        GameMgr.Inst.battleFSM.OnUpdate();

        if (GameMgr.Inst.battleFSM.IsGameState())
            GameMgr.Inst.CalTime();
    }

    void ClearBullets()
    {
        for (int i = 0; i < m_Bullets.childCount; i++)
        {
            Destroy(m_Bullets.GetChild(i).gameObject);
        }
    }

}