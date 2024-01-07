using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetStage : Asset
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

public class AssetItem : Asset
{
    public int m_ItemType = 0;
    public string m_PrefabName = string.Empty;
    public int m_Value = 0;
    public string m_Desc = string.Empty;
}

public class Asset
{
    public int m_id;
}

public class AssetMgr
{
    static AssetMgr _inst = null;
    public static AssetMgr Inst
    {
        get
        {
            if (_inst == null)
                _inst = new AssetMgr();

            return _inst;
        }
    }

    private AssetMgr() { }

    public List<AssetStage> listStage = new List<AssetStage>();
    public List<AssetItem> listItem = new List<AssetItem>();


    public void Init()
    {
        InitStage("Tabledata/stage");
        InitItem("Tabledata/item");
    }

    public void InitStage(string path)
    {
        listStage.Clear();
        List<string[]> datas = CSVParser.Load(path);
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

            listStage.Add(stage);
        }
        datas.Clear();
    }

    public void InitItem(string path)
    {
        listItem.Clear();

        List<string[]> datas = CSVParser.Load(path);

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

            listItem.Add(item);
        }
        datas.Clear();
    }
}
