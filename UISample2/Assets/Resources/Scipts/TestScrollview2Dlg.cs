using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScrollview2Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnReset = null;

    [SerializeField] GameObject m_preItemSlot = null;

    string[] m_city = new string[6] { "서울", "도쿄", "베이징", "파리", "런던", "베른" };

    List<ItemSlot> m_items = new List<ItemSlot>();
    int m_cityIdx = 0;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnReset.onClick.AddListener(OnClicked_Reset);

        SetItem();
    }

    void SetItem()
    {
        for (int i = 0; i < m_city.Length; i++)
        {
            GameObject go = Instantiate(m_preItemSlot, m_scroll.content);

            ItemSlot item = go.GetComponent<ItemSlot>();
            item.Init(m_city[i]);
            m_items.Add(item);

            int idx = i;
            item.GetComponent<Button>().onClick.AddListener(() => OnClicked_Item(idx));
        }
    }

    void OnClicked_Item(int idx)
    {
        ClearList();

        m_items[idx].m_image.color = Color.green;
        m_cityIdx = idx;
        m_txtResult.text = m_items[idx].m_txtCity.text;
    }

    void OnClicked_Ok()
    {
        string str = $"당신이 이동할 도시는 {m_items[m_cityIdx].m_txtCity.text} 입니다.";
        m_txtResult.text = str;
    }

    void OnClicked_Reset()
    {
        m_txtResult.text = string.Empty;
        m_cityIdx = 0;
        ClearList();
    }

    void ClearList()
    {
        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].m_image.color = Color.white;
        }
    }

}