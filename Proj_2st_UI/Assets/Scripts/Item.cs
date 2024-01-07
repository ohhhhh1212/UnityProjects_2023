using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Image ������Ʈ
    Image img;

    // Button ������Ʈ
    Button btn;

    // ItemManager ������Ʈ(��ũ��Ʈ)
    ItemManager itemMgr;

    // ������ ��� ����
    bool isUse = false;

    public int Index
    {
        get;
        private set;
    }

    void Awake()
    {
        img = GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Btn_Click);
    }

    // ��ư �̺�Ʈ - ������ ���
    void Btn_Click()
    {
        // ����� �������� ���� ���
        if (isUse == false)
            return;

        Debug.Log("������ �����");

        itemMgr.Refresh(this);
        Destroy(gameObject);
    }

    // 1. �ܺο��� ������ �˷��ָ�, �� ������ ���缭 ���� ���� ����
    // -> ���� : �ٲ�� �ϴ� �̹���
    public void SetItem(Sprite newImg)
    {
        // ��� ����
        isUse = true;

        // ���ο� �̹����� ����
        img.sprite = newImg;
        SetColor(1f);
    }

    // �ʱ�ȭ �Լ�
    public void Init(ItemManager mgr)
    {
        if(itemMgr == null)
        {
            // ItemManager ���
            itemMgr = mgr;
        }

        // ������  ��� �����ϵ��� ����
        isUse = false;

        // �̹��� ����
        img.sprite = null;
        SetColor(0.5f);
    }

    void SetColor(float alpha)
    {
        // ���İ� ����
        Color newColor = img.color;
        newColor.a = alpha;
        img.color = newColor;
    }

}
