using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> m_preItems = null;

    public FXSerialize m_FXHeal;
    public FXSerialize m_FXExplose;
    public AudioSource m_SFXHeal;
    public AudioSource[] m_SFXBomb;

    [SerializeField] Transform Pos1 = null;
    [SerializeField] Transform Pos2 = null;
    [SerializeField] Transform itemParent = null;

    float m_spawnDelay;
    float m_keepTime;

    public void Init()
    {
        m_spawnDelay = GameMgr.Inst.gameInfo.m_ItemAppearDelay;
        m_keepTime = GameMgr.Inst.gameInfo.m_ItemKeepTime;

        for (int i = 0; i < AssetMgr.Inst.listItem.Count; i++)
        {
            m_preItems.Add(Resources.Load<GameObject>(AssetMgr.Inst.listItem[i].m_PrefabName));
            int type = AssetMgr.Inst.listItem[i].m_ItemType;
            int value = AssetMgr.Inst.listItem[i].m_Value;

            m_preItems[i].AddComponent<ItemObj>().Init(type, value);
        }

        m_SFXHeal.playOnAwake = GameMgr.Inst.isSFX;
        for (int i = 0; i < m_SFXBomb.Length; i++)
        {
            m_SFXBomb[i].playOnAwake = GameMgr.Inst.isSFX;
        }
    }

    public void ClearItem()
    {
        for (int i = 0; i < itemParent.childCount; i++)
        {
            Destroy(itemParent.GetChild(i).gameObject);
        }
    }

    void SpawnItem()
    {
        int ran = Random.Range(0, m_preItems.Count);

        float xPos = Random.Range(Pos2.position.x, Pos1.position.x);
        float zPos = Random.Range(Pos2.position.z, Pos1.position.z);

        GameObject item = Instantiate(m_preItems[ran].gameObject);
        item.transform.position = new Vector3(xPos, 1.8f, zPos);
        item.transform.SetParent(itemParent);

        Destroy(item, m_keepTime);
    }

    public IEnumerator Co_SpawnItem()
    {
        while (GameMgr.Inst.battleFSM.IsGameState())
        {
            yield return new WaitForSeconds(m_spawnDelay);

            if (!GameMgr.Inst.battleFSM.IsGameState())
                break;

            SpawnItem();
        }
    }

    public void PlayFXHeal()
    {
        m_FXHeal.Play();

        Invoke("StopHeal", 3f);
    }

    void StopHeal()
    {
        m_FXHeal.Stop();
    }

    public void PlayFXExplose()
    {
        m_FXExplose.Play();

        Invoke("StopExplose", 3f);
    }

    void StopExplose()
    {
        m_FXExplose.Stop();
    }

}
