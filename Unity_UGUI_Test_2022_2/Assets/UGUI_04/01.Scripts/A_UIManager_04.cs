using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_UIManager_04 : MonoBehaviour
{
    [SerializeField]
    A_FillAmountOfSlider_04 hpBar;

    [SerializeField]
    A_FillAmountOfSlider_04 expBar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            hpBar.SetMinusSlider(0.5f);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            hpBar.SetPlusSlider(0.1f);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            expBar.SetMinusSlider(0.1f);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            expBar.SetPlusSlider(0.1f);

    }
}
