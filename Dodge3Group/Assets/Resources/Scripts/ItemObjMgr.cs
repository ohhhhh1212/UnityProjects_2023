using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjMgr : MonoBehaviour
{
    float m_spwanTime = 0f;
    float m_keepTime = 0f;
    int m_curStage = 1;
    bool m_isSpawn = true;

    [SerializeField] GameObject[] itemPrefabs;

    AssetStage stage;
    AssetItem item;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        AssetMgr.Inst.Init();
        stage = AssetMgr.Inst.m_listStages[m_curStage];
        item = AssetMgr.Inst.m_listItems[m_curStage];

        m_spwanTime = stage.m_ItemAppearDelay;
        m_keepTime = stage.m_ItemKeepTime;
    }

    void SpawnItem()
    {
        int ran = Random.Range(0, itemPrefabs.Length);
        float ranX = Random.Range(-10f, 10f);
        float ranZ = Random.Range(-10f, 10f);

        GameObject obj = Instantiate(itemPrefabs[ran]);
        obj.transform.position = new Vector3(ranX, 1, ranZ);
        StartCoroutine(Co_DestroyObj(m_keepTime, obj));
    }

    IEnumerator Co_DestroyObj(float t, GameObject obj)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
    }

    public IEnumerator Co_ItemSpawn()
    {
        while (m_isSpawn)
        {
            SpawnItem();

            yield return new WaitForSeconds(m_spwanTime);
        }
    }

    public void Stop_ItemSpawn()
    {
        m_isSpawn = false;
    }
}
