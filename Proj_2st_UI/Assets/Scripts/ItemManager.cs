using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // Grid Layout Group 컴포넌트
    [SerializeField]
    GridLayoutGroup grid;

    // Item Prefab
    [SerializeField]
    GameObject prefab_Item;

    [SerializeField]
    Button btn;

    // 생성된 Item들을 저장할 변수
    List<Item> items = new List<Item>();
    // 아이템 생성 카운트
    int spawnCount = 0;
    int maxCount = 0;

    // 아이템 이미지 목록
    [SerializeField]
    Sprite[] sprite_Items;

    void Start()
    {
        maxCount = (int)Mathf.Pow(grid.constraintCount, 2f);
        for (int i = 0; i < maxCount; i++)
        {
            Create();
        }
        btn.onClick.AddListener(Btn_Click);
    }

    void Create()
    {
        // item 생성
        GameObject obj = GameObject.Instantiate(prefab_Item);
        obj.transform.SetParent(grid.transform);
        obj.transform.localScale = Vector3.one;

        // List 추가
        Item item = obj.GetComponent<Item>();
        items.Add(item);

        // item Init 함수 호출
        item.Init(this);
    }

    void Btn_Click()
    {
        if (spawnCount >= maxCount)
            return;

        int ran = Random.Range(0, sprite_Items.Length);
        items[spawnCount].SetItem(sprite_Items[ran]);
        spawnCount++;
    }

    // 아이템 List 재배치
    public void Refresh(Item item)
    {
        // 1. 삭제된 아이템을 List에서 제거
        items.Remove(item);
        // 2. 아이템 List 생성 및 추가
        Create();

        spawnCount--;
    }

}
