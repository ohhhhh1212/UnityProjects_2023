using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Image 컴포넌트
    Image img;

    // Button 컴포넌트
    Button btn;

    // ItemManager 컴포넌트(스크립트)
    ItemManager itemMgr;

    // 아이템 사용 여부
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

    // 버튼 이벤트 - 아이템 사용
    void Btn_Click()
    {
        // 사용할 아이템이 없는 경우
        if (isUse == false)
            return;

        Debug.Log("아이템 사용함");

        itemMgr.Refresh(this);
        Destroy(gameObject);
    }

    // 1. 외부에서 정보를 알려주면, 그 정보에 맞춰서 내가 직접 세팅
    // -> 정보 : 바꿔야 하는 이미지
    public void SetItem(Sprite newImg)
    {
        // 사용 가능
        isUse = true;

        // 새로운 이미지로 변경
        img.sprite = newImg;
        SetColor(1f);
    }

    // 초기화 함수
    public void Init(ItemManager mgr)
    {
        if(itemMgr == null)
        {
            // ItemManager 등록
            itemMgr = mgr;
        }

        // 아이템  사용 가능하도록 변경
        isUse = false;

        // 이미지 삭제
        img.sprite = null;
        SetColor(0.5f);
    }

    void SetColor(float alpha)
    {
        // 알파값 조절
        Color newColor = img.color;
        newColor.a = alpha;
        img.color = newColor;
    }

}
