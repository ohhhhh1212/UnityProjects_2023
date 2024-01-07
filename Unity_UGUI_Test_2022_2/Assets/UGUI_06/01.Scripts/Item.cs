using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    Image img;

    Button btn;

    UIManager_06 uiMgr;

    void Awake()
    {
        img = GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Btn_Click);
    }

    public void SetImage(Sprite sprite)
    {
        img.sprite = sprite;
    }

    void Btn_Click()
    {
        Debug.Log("ddd");
        uiMgr.Refresh(this);
        Destroy(gameObject);
    }


}
