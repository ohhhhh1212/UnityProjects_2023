using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_ItemSlotManager : MonoBehaviour
{
    [System.Serializable]
    public class ItemSlot
    {
        public Button btn;
        public bool isActive;
    }

    [SerializeField]
    ItemSlot[] itemSlots;

    A_ItemList itemList;

    void Start()
    {
        itemList = FindObjectOfType<A_ItemList>();

        for (int i = 0; i < itemSlots.Length; i++)
        {
            int idx = i;
            itemSlots[i].btn.onClick.AddListener(() => { Event_BtnClick(idx); });
        }
    }

    public void SetButton(Sprite newImg)
    {
        int idx = GetSlotIndex();
        if (idx == -1)
        {
            Debug.Log("모든 버튼이 사용중입니다");
            return;
        }

        itemSlots[idx].isActive = true;
        itemSlots[idx].btn.image.sprite = newImg;
    }

    int GetSlotIndex()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isActive == false)
                return i;
        }

        return -1;
    }

    void Event_BtnClick(int idx)
    {
        Sprite temp = itemSlots[idx].btn.image.sprite;
        itemSlots[idx].btn.image.sprite = null;

        itemSlots[idx].isActive = false;

        itemList.AddObj(temp);
    }
}
