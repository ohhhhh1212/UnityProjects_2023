using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_04 : MonoBehaviour
{
    [SerializeField]
    Button btn_attack;
    [SerializeField]
    Button btn_recovery;
    [SerializeField]
    Text txt_Recovery;
    [SerializeField]
    Image hp;
    [SerializeField]
    Text txt_Lv;
    [SerializeField]
    Image exp;


    int level = 1;
    int recovery = 1;
    float maxHp = 50f;
    int maxExp = 10;
    float coolTime = 0.5f;

    void Start()
    {
        btn_attack.onClick.AddListener(Attack);
        btn_recovery.onClick.AddListener(Recovery);
        exp.fillAmount = 0f;
    }


    void Attack()
    {
        int ran_Attack = Random.Range(1, 100);
        int count = 0;

        for (int i = 2; i < ran_Attack; i++)
        {
            if (ran_Attack % i == 0)
                count++;
        }

        if (count == 0)
        {
            level++;
            recovery++;
            exp.fillAmount = 0f;
        }
        else
        {
            float ran_Exp = Random.Range(1f, 3f);
            float attack_Damage = Random.Range(3f, 5f);
            StartCoroutine(SetExp());
            hp.fillAmount -= attack_Damage / maxHp;
        }

        if (exp.fillAmount == 1f)
        {
            level++;
            recovery++;
            exp.fillAmount = 0f;
        }
        Set();
    }

    void Recovery()
    {
        hp.fillAmount += (maxHp / 30f) * 100f;
        recovery--;
        Set();
    }

    void Set()
    {
        txt_Lv.text = $"[Lv. {level}]";
        txt_Recovery.text = $"Recovery[{recovery}]";
    }

    IEnumerator SetExp() 
    {
        float time = 0f;
        while (true)
        {
            yield return null;

            time += Time.deltaTime;
            if (time >= coolTime)
            {
                exp.fillAmount = 0f;
                yield break;
            }
            else
            {
                exp.fillAmount += Time.deltaTime / coolTime;
            }
        }
    }
}
