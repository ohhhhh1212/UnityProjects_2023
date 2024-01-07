using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_UIManager_03 : MonoBehaviour
{
    // 슬라이더 컴포넌트
    [SerializeField]
    Slider slider;

    // 이미지 컴포넌트
    [SerializeField]
    Image img;

    // 바꿀 이미지에 대한 변수(배열)
    [SerializeField]
    Sprite[] sprite_changeImages;

    // 이미지 변경 트리거 변수
    bool isChanged = false;
    int imageIndex = 0;

    void Start()
    {
        Init();

        // Slider Event 등록
        slider.onValueChanged.AddListener(Event_SliderChanged);
    }

    void Init()
    {
        // Slider 기능 초기화
        slider.value = 1f;
    }

    void Event_SliderChanged(float value)
    {
        ChangeImageColor(value);

        // value == 0 : 이미지 변경
        if (value == 0)
        {
            // value == 1이 한번 이라도 됐을 상태일때만 이미지 변경
            if (isChanged)
            {
                // 이미지 변경
                imageIndex = (imageIndex + 1) % sprite_changeImages.Length;
                img.sprite = sprite_changeImages[imageIndex];
            }
        }

        if(value == 1)
        {
            isChanged = true;
        }
    }

    void ChangeImageColor(float alpha)
    {
        // 기존 이미지 Color 값 저장(캐스팅)
        Color newColor = img.color;
        // Color 값 중에서 Alpha 값만 수정
        newColor.a = alpha;

        // 기존 이미지 Color 설정
        img.color = newColor;
    }

    void ChangeImage()
    {

    }
}
