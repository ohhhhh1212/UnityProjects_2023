using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetStage : CAsset
{
    public float m_FireDelayTime = 0f;
    public float m_BulletSpeed = 0f;
    public float m_KeepTime = 0f;
    public int m_PlayerHp = 0;
    public int m_BulletAttack = 0;
    public float m_ItemAppearDelay = 0f;
    public float m_ItemKeepTime = 0;
    public int m_TurretCount = 0;
}

public class AssetItem : CAsset
{
    public int m_ItemType = 0;
    public string m_PrefabName = string.Empty;
    public int m_Value = 0;
    public string m_Desc = string.Empty;
}

public class CAsset
{
    public int m_id;
}

public class AssetMgr
{
    static AssetMgr _intstance = null;
    public static AssetMgr Inst
    {
        get
        {
            if (_intstance == null)
                _intstance = new AssetMgr();

            return _intstance;
        }
    }


    private AssetMgr() { }

    public List<AssetStage> m_listStages = new List<AssetStage>();
    public List<AssetItem> m_listItems = new List<AssetItem>();
    public bool IsInstalled = false;

    public void Init()
    {
        InitStage("TableData/stage");
        InitItem("TableData/item");
        IsInstalled = true;
    }

    public void InitStage(string pathName)
    {
        m_listStages.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null) return;

        for (int i = 1; i < datas.Count; i++)
        {
            string[] str = datas[i];
            AssetStage stage = new AssetStage();
            int idx = 0;
            stage.m_id = int.Parse(str[idx++]);
            stage.m_FireDelayTime = float.Parse(str[idx++]);
            stage.m_BulletSpeed = float.Parse(str[idx++]);
            stage.m_KeepTime = float.Parse(str[idx++]);
            stage.m_PlayerHp = int.Parse(str[idx++]);
            stage.m_BulletAttack = int.Parse(str[idx++]);
            stage.m_ItemAppearDelay = float.Parse(str[idx++]);
            stage.m_ItemKeepTime = float.Parse(str[idx++]);
            stage.m_TurretCount = int.Parse(str[idx++]);

            m_listStages.Add(stage);
        }
        datas.Clear();
    }

    public void InitItem(string pathName)
    {
        m_listItems.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null) return;

        for (int i = 1; i < datas.Count; i++)
        {
            string[] str = datas[i];
            AssetItem item = new AssetItem();
            int idx = 0;

            item.m_id = int.Parse(str[idx++]);
            item.m_ItemType = int.Parse(str[idx++]);
            item.m_PrefabName = str[idx++];
            item.m_Value = int.Parse(str[idx++]);
            item.m_Desc = str[idx++];

            m_listItems.Add(item);
        }
        datas.Clear();
    }
}
