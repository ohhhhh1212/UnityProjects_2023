using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_03 : MonoBehaviour
{
    [SerializeField]
    Image main_Img;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Sprite[] sprites;

    int curnum = 0;

    bool canChange = true;

    private void Start()
    {
        slider.onValueChanged.AddListener(Set);
    }

    void Set(float value)
    {
        if (value == 1 && canChange)
        {
            main_Img.sprite = sprites[curnum];
            curnum = (curnum + 1) % sprites.Length;
            canChange = false;
        }
        else if (value == 0)
            canChange = true;


        Color color = main_Img.color;
        color.a = value;
        main_Img.color = color;
    }
}
