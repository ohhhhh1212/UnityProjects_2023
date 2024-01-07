using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_02 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Image main_Img;

    Sprite image;

    void Start()
    {
        buttons[0].onClick.AddListener(OnClick_1);
        buttons[1].onClick.AddListener(OnClick_2);
        buttons[2].onClick.AddListener(OnClick_3);
    }

    void OnClick_1()
    {
        image = buttons[0].image.sprite;
        buttons[0].image.sprite = main_Img.sprite;
        main_Img.sprite = image;
    }
    void OnClick_2()
    {
        image = buttons[1].image.sprite;
        buttons[1].image.sprite = main_Img.sprite;
        main_Img.sprite = image;
    }
    void OnClick_3()
    {
        image = buttons[2].image.sprite;
        buttons[2].image.sprite = main_Img.sprite;
        main_Img.sprite = image;
    }
}
