using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string m_name = "";
    public int m_hp = 0;

    public Monster(string s, int i)
    {
        m_name = s;
        m_hp = i;
    }

    public void SetHp(int h)
    {
        if (m_hp - h <= 0)
            m_hp = 0;
        else
            m_hp -= h;
    }
}
