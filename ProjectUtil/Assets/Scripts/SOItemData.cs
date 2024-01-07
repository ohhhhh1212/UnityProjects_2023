using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName = "ScriptableObject/ItemData", order = 1)]
public class SOItemData : ScriptableObject
{
    [Serializable]
    public class SItem
    {
        public int id = 0;
        public int itemType = 1;
        public string itemPrefab = "";
        public float itemValue = 0;
    }

    public List<SItem> items = new List<SItem>();

    // �ݵ�� ��� file�� ������ ��
    public SOItemData() : base() { }
}
