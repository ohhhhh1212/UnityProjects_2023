using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_ItemInfo : MonoBehaviour
{
    // 자신의 이미지 저장 변수
    Sprite myImg;
    // 자신의 Image 컴포넌트
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
