using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_ItemInfo : MonoBehaviour
{
    // �ڽ��� �̹��� ���� ����
    Sprite myImg;
    // �ڽ��� Image ������Ʈ
    Image img;

    Button btn;
    // ItemSlotManager
    A_ItemSlotManager itemSlotMgr;

    A_ItemList itemList;

    public void Init(Sprite newImg)
    {
        itemSlotMgr = FindObjectOfType<A_ItemSlotManager>();
        itemList = FindObjectOfType<A_ItemList>();

        btn = GetComponent<Button>();
        btn.onClick.AddListener(Event_BtnClick);
        img = GetComponent<Image>();
        img.sprite = newImg;
        myImg = newImg;
    }

    void Event_BtnClick()
    {
        itemSlotMgr.SetButton(myImg);
        itemList.RemoveObject(this);
    }
}
