using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScrollviewDlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnReset = null;

    [SerializeField] GameObject m_preItem = null;

    string[] m_animals = new string[5] { "개", "고양이", "호랑이", "원숭이", "코뿔소" };
    int m_animalsIdx;

    List<Item1> m_items = new List<Item1>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnReset.onClick.AddListener(OnClicled_Reset);

        SetItem();
    }

    void SetItem()
    {
        for (int i = 0; i < m_animals.Length; i++)
        {
            GameObject go = Instantiate(m_preItem, m_scroll.content);

            Item1 item = go.GetComponent<Item1>();
            item.Init(m_animals[i]);
            m_items.Add(item);

            int idx = i;
            go.GetComponent<Button>().onClick.AddListener(() => OnClicked_Item(idx));
        }
    }

    void OnClicked_Item(int idx)
    {
        ClearItemList();
        m_items[idx].m_txt.color = Color.red;

        m_txtResult.text = $"{m_animals[idx]}";
        m_animalsIdx = idx;
    }

    void OnClicked_Ok()
    {
        string str = $"당신이 선택한 동물은 {m_animals[m_animalsIdx]} 입니다.";
        m_txtResult.text = str;
    }

    void OnClicled_Reset()
    {
        m_txtResult.text = string.Empty;
        m_animalsIdx = 0;
        ClearItemList();
    }

    void ClearItemList()
    {
        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].m_txt.color = Color.white;
        }
    }
}
