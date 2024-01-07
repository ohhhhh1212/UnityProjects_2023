using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : EventTrigger
{
    public delegate void DelegateFunc();
    public DelegateFunc selectedItem = null;

    Image m_myImg = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_myImg = GetComponent<Image>();
    }

    public void OnAddListner(DelegateFunc func)
    {
        selectedItem = new DelegateFunc(func);
    }

    public void OnClicked_Select()
    {
        if (selectedItem != null)
            selectedItem();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        m_myImg.color = Color.green;

        OnClicked_Select();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        m_myImg.color = Color.white;
    }
}
