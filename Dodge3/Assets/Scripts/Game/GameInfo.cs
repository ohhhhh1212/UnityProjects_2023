using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    public int m_id;
    public float m_FireDelayTime = 0f;
    public float m_BulletSpeed = 0f;
    public float m_KeepTime = 0f;
    public int m_PlayerHp = 0;
    public int m_BulletAttack = 0;
    public float m_ItemAppearDelay = 0f;
    public float m_ItemKeepTime = 0;
    public int m_TurretCount = 0;


    public void Init(int idx)
    {
        AssetStage stage = AssetMgr.Inst.listStage[idx];

        m_id = stage.m_id;
        m_FireDelayTime = stage.m_FireDelayTime;
        m_BulletSpeed = stage.m_BulletSpeed;
        m_KeepTime = stage.m_KeepTime;
        m_PlayerHp = stage.m_PlayerHp;
        m_BulletAttack = stage.m_BulletAttack;
        m_ItemAppearDelay = stage.m_ItemAppearDelay;
        m_ItemKeepTime = stage.m_ItemKeepTime;
        m_TurretCount = stage.m_TurretCount;
    }
}
