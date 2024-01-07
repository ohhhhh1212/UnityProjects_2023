using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test015Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtHp = null;
    [SerializeField] Slider m_sldHp = null;
    [SerializeField] Toggle m_togDamage = null;
    [SerializeField] Toggle m_togHeal = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Button m_btnReset = null;

    bool m_isStop = true;
    bool m_isHeal = false;

    int m_hp = 150;

    float t = 0f;

    private void Update()
    {
        if(t <= 1f && !m_isStop)
        {
            t += Time.deltaTime;
            
            if(t >= 1f && !m_isHeal)
            {
                m_hp -= 10;
                t = 0f;
            }
            else if(t >= 1f && m_isHeal)
            {
                m_hp += 15;
                t = 0f;
            }

            m_txtHp.text = $"{m_hp} / 200";
            m_sldHp.value = m_hp;
        }
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
        m_togDamage.onValueChanged.AddListener(OnValueChanged_Damage);
        m_togHeal.onValueChanged.AddListener(OnValueChanged_Heal);
    }

    void OnValueChanged_Damage(bool b)
    {
        m_isHeal = false;
    }

    void OnValueChanged_Heal(bool b)
    {
        m_isHeal = true;
    }

    void OnClicked_Start()
    {
        m_isStop = false;
    }

    void OnClicked_Stop()
    {
        m_isStop = true;
    }

    void OnClicked_Reset()
    {
        m_hp = 150;
        m_txtHp.text = $"{m_hp} / 200";
        m_isStop = true;
        m_isHeal = false;
        m_sldHp.value = 150f;
    }
}
