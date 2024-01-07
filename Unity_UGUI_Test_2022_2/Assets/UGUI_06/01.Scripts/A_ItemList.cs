using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_ItemList : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    GameObject prefab_Item;

    [SerializeField]
    Transform parent_Content;

    List<A_ItemInfo> itemInfos;

    void Start()
    {
        itemInfos = new List<A_ItemInfo>();
        for (int i = 0; i < sprites.Length; i++)
        {
            AddObj(sprites[i]);
        }
    }

    public void RemoveObject(A_ItemInfo info)
    {
        Destroy(info.gameObject);
        itemInfos.Remove(info);
    }

    public void AddObj(Sprite newImg)
    {
        // prefab_Item 생성 후 -> 부모를 parent_Content로 설정
        GameObject temp = Instantiate(prefab_Item, parent_Content);
        A_ItemInfo info = temp.GetComponent<A_ItemInfo>();
        info.Init(newImg);
        itemInfos.Add(info);
    }
}
