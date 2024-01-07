using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Transform m_Bulletlist = null;
    public Turret[] m_Turrets = null;
    public Player m_Player = null;
    public ItemSpawner m_Spawner = null;

    void Start()
    {
        
    }

    void Update()
    {
        GameMgr.Inst.battleFSM.OnUpdate();
    }

    public void Init()
    {
        m_Spawner.Init();
        m_Spawner.ClearItem();
        m_Player.Init();
        InitTurret();
    }

    public void InitTurret()
    {
        for (int i = 0; i < GameMgr.Inst.gameInfo.m_TurretCount; i++)
        {
            m_Turrets[i].gameObject.SetActive(true);
            m_Turrets[i].Init(m_Player.transform, m_Bulletlist);
        }
    }

    public void StartTurret()
    {
        for (int i = 0; i < GameMgr.Inst.gameInfo.m_TurretCount; i++)
        {
            m_Turrets[i].StartShoot();
        }
    }

    public void StartSpawnItem()
    {
        StartCoroutine(m_Spawner.Co_SpawnItem());
    }

    public void PauseTurret(float time)
    {
        for (int i = 0; i < GameMgr.Inst.gameInfo.m_TurretCount; i++)
        {
            m_Turrets[i].PauseShoot(time);
        }
    }

    public void StartHeal()
    {
        m_Spawner.PlayFXHeal();
    }

    public void StartBomb(float time)
    {
        m_Spawner.PlayFXExplose();

        for (int i = 0; i < m_Bulletlist.childCount; i++)
        {
            Destroy(m_Bulletlist.GetChild(i).gameObject);
        }

        PauseTurret(time);
    }
}
