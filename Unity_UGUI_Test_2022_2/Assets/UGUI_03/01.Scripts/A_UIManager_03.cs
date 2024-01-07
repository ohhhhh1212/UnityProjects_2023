using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_UIManager_03 : MonoBehaviour
{
    // �����̴� ������Ʈ
    [SerializeField]
    Slider slider;

    // �̹��� ������Ʈ
    [SerializeField]
    Image img;

    // �ٲ� �̹����� ���� ����(�迭)
    [SerializeField]
    Sprite[] sprite_changeImages;

    // �̹��� ���� Ʈ���� ����
    bool isChanged = false;
    int imageIndex = 0;

    void Start()
    {
        Init();

        // Slider Event ���
        slider.onValueChanged.AddListener(Event_SliderChanged);
    }

    void Init()
    {
        // Slider ��� �ʱ�ȭ
        slider.value = 1f;
    }

    void Event_SliderChanged(float value)
    {
        ChangeImageColor(value);

        // value == 0 : �̹��� ����
        if (value == 0)
        {
            // value == 1�� �ѹ� �̶� ���� �����϶��� �̹��� ����
            if (isChanged)
            {
                // �̹��� ����
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
        // ���� �̹��� Color �� ����(ĳ����)
        Color newColor = img.color;
        // Color �� �߿��� Alpha ���� ����
        newColor.a = alpha;

        // ���� �̹��� Color ����
        img.color = newColor;
    }

    void ChangeImage()
    {

    }
}
