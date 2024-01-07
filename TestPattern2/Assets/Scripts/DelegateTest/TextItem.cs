using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public delegate void DelegateFunc(TextItem textItem);
    public DelegateFunc OnSelectedFunc = null;

    public Image m_btnImage = null;
    public Text m_txt = null;
    Button m_btn = null;

    private void Start()
    {
        m_btn = GetComponent<Button>();
        m_btn.onClick.AddListener(OnClicked_Select);
    }

    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }

    public void OnClicked_Select()
    {
        if (OnSelectedFunc != null)
            OnSelectedFunc(this);
    }
}
