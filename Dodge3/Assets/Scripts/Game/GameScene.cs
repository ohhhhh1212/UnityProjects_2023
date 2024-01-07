using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] AudioSource m_bgm = null;
    public GameUI m_GameUI = null;
    public HudUI m_HudUI = null;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GameMgr.Inst.battleFSM.Initialize(ReadyState, GameState, ResultState);
        AssetMgr.Inst.Init();
        GameMgr.Inst.saveInfo.Load();


        if (PlayerPrefs.GetInt("BGM") == 1)
            m_bgm.Play();

        GameMgr.Inst.isSFX = PlayerPrefs.GetInt("SFX") == 1;

        GameMgr.Inst.battleFSM.SetReadyState();

    }

    void ReadyState()
    {
        GameMgr.Inst.gameInfo.Init(GameMgr.Inst.curStage - 1);
        m_HudUI.Init();
        m_GameUI.Init();
    }

    void GameState()
    {
        m_GameUI.StartTurret();
        m_GameUI.StartSpawnItem();
    }

    void ResultState()
    {
        GameMgr.Inst.AddScoreList();
        GameMgr.Inst.saveInfo.Save();

        bool isClear = GameMgr.Inst.gameInfo.m_PlayerHp > 0;
        m_HudUI.m_ResultUI.SetResultUI(isClear);
    }

    private void OnApplicationQuit()
    {
        GameMgr.Inst.saveInfo.Save();
    }
}
