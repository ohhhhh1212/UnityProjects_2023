using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_FillAmountOfSlider_04 : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    [SerializeField]
    float delay = 0.5f;

    Image img;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetPlusSlider(float percent)
    {
        StartCoroutine(Co_Update(percent, true));
    }

    public void SetMinusSlider(float percent)
    {
        StartCoroutine(Co_Update(percent, false));
    }

    IEnumerator Co_Update(float percent, bool plus)
    {
        // 내부에서 사용될 시간 변수
        float t = 0f;

        while (true)
        {
            // 1 프레임 대기
            yield return null;

            t += Time.deltaTime;
            if(t >= delay)
            {
                // 현재 함수가 딜레이 시간만큼 동작 -> 함수 종료
                img.fillAmount = (int)(img.fillAmount * 100) * 0.01f;
                if (plus)
                    img.fillAmount += 0.01f;
                yield break;
            }

            // HP Bar 처리
            if(plus)
                img.fillAmount += percent * Time.deltaTime * (1f / delay);
            else
                img.fillAmount -= percent * Time.deltaTime * (1f / delay);

        }
    }
}
