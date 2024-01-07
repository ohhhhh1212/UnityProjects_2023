using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_06 : MonoBehaviour
{
    [SerializeField]
    GameObject prefab_Item;

    [SerializeField]
    GridLayoutGroup grid;

    [SerializeField]
    Sprite[] sprites;

    public Button[] btns;
    
    [HideInInspector]
    public int slotCount = 0;

    List<Item> items = new List<Item>();

    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            Create();
        }

    }


    void Create()
    {
        int ran = Random.Range(0, sprites.Length);
        GameObject obj = GameObject.Instantiate(prefab_Item);
        obj.transform.SetParent(grid.transform);
        obj.transform.localScale = Vector3.one;
        
        Item item = obj.GetComponent<Item>();
        item.SetImage(sprites[ran]);
        items.Add(item);

    }

    public void Refresh(Item item)
    {
        items.Remove(item);
        items.Add(item);

    }

}
