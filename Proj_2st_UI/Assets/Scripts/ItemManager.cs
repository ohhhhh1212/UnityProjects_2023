using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // Grid Layout Group ������Ʈ
    [SerializeField]
    GridLayoutGroup grid;

    // Item Prefab
    [SerializeField]
    GameObject prefab_Item;

    [SerializeField]
    Button btn;

    // ������ Item���� ������ ����
    List<Item> items = new List<Item>();
    // ������ ���� ī��Ʈ
    int spawnCount = 0;
    int maxCount = 0;

    // ������ �̹��� ���
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
        // item ����
        GameObject obj = GameObject.Instantiate(prefab_Item);
        obj.transform.SetParent(grid.transform);
        obj.transform.localScale = Vector3.one;

        // List �߰�
        Item item = obj.GetComponent<Item>();
        items.Add(item);

        // item Init �Լ� ȣ��
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

    // ������ List ���ġ
    public void Refresh(Item item)
    {
        // 1. ������ �������� List���� ����
        items.Remove(item);
        // 2. ������ List ���� �� �߰�
        Create();

        spawnCount--;
    }

}
