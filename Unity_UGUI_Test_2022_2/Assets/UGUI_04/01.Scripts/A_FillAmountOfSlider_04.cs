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
        // ���ο��� ���� �ð� ����
        float t = 0f;

        while (true)
        {
            // 1 ������ ���
            yield return null;

            t += Time.deltaTime;
            if(t >= delay)
            {
                // ���� �Լ��� ������ �ð���ŭ ���� -> �Լ� ����
                img.fillAmount = (int)(img.fillAmount * 100) * 0.01f;
                if (plus)
                    img.fillAmount += 0.01f;
                yield break;
            }

            // HP Bar ó��
            if(plus)
                img.fillAmount += percent * Time.deltaTime * (1f / delay);
            else
                img.fillAmount -= percent * Time.deltaTime * (1f / delay);

        }
    }
}
