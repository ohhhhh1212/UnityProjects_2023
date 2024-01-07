using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AssetMgrTestDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnStage = null;
    [SerializeField] Button m_btnItem = null;
    [SerializeField] Button m_btnClear = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        AssetMgr.Inst.Init();
        m_btnStage.onClick.AddListener(OnClicked_Stage);
        m_btnItem.onClick.AddListener(OnClicked_Item);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Stage()
    {
        List<AssetStage> liststage = AssetMgr.Inst.m_listStages;
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < liststage.Count; i++)
        {
            AssetStage stage = liststage[i];
            int id = stage.m_id;
            float firedelay = stage.m_FireDelayTime;
            float bulletspeed = stage.m_BulletSpeed;
            float keeptime = stage.m_KeepTime;
            int hp = stage.m_PlayerHp;
            int attack = stage.m_BulletAttack;
            float appeardelay = stage.m_ItemAppearDelay;
            float itemkeeptime = stage.m_ItemKeepTime;
            int turretCount = stage.m_TurretCount;

            string str = $"{id}, {firedelay}, {bulletspeed}, {keeptime}, {hp}, {attack}, {appeardelay}, {itemkeeptime}, {turretCount}\n";

            builder.Append(str);
        }

        m_txtResult.text = builder.ToString();
    }

    void OnClicked_Item()
    {
        List<AssetItem> listitem = AssetMgr.Inst.m_listItems;
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < listitem.Count; i++)
        {
            AssetItem item = listitem[i];
            int id = item.m_id;
            int itemtype = item.m_ItemType;
            string preName = item.m_PrefabName;
            int value = item.m_Value;
            string desc = item.m_Desc;

            string str = $"{id}, {itemtype}, {preName}, {value}, {desc}\n";

            builder.Append(str);
        }

        m_txtResult.text = builder.ToString();
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "Clear";
    }
}
