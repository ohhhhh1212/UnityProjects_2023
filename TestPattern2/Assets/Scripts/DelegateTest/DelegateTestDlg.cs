using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTestDlg : MonoBehaviour
{
    [SerializeField] TextItem[] m_textItems = null;
    [SerializeField] Text m_txtCity = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnReset = null;

    TextItem m_selectedItem = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < m_textItems.Length; i++)
        {
            m_textItems[i].OnAddListner(OnClicked_TextItem);
        }

        m_btnOk.onClick.AddListener(OnClicked_OK);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
    }

    void OnClicked_TextItem(TextItem item)
    {
        ResetItemsColor();
        item.m_btnImage.color = Color.green;
        m_txtCity.text = item.m_txt.text;
        m_selectedItem = item;
    }

    void OnClicked_OK()
    {
        if(m_selectedItem == null)
        {
            print("목적지를 선택하세요");
            return;
        }

        string str = $"당신이 목적지는 {m_selectedItem.m_txt.text}입니다.";
        m_txtCity.text = str;
    }

    void OnClicked_Reset()
    {
        ResetItemsColor();
        m_txtCity.text = "";
        m_selectedItem = null;
    }


    void ResetItemsColor()
    {
        for (int i = 0; i < m_textItems.Length; i++)
        {
            m_textItems[i].m_btnImage.color = Color.white;
        }
    }

}
