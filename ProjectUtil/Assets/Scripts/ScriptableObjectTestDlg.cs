using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectTestDlg : MonoBehaviour
{
    private void Start()
    {
        Load();
    }

    void Load()
    {
        SOItemData itemData = Resources.Load<SOItemData>("Items/ItemData");

        for (int i = 0; i < itemData.items.Count; i++)
        {
            print(itemData.items[i].id);
        }
    }
}
