using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string m_name = "";
    public int m_weight = 0;

    public void Setting(string s, int i)
    {
        m_name = s;
        m_weight = i;
    }

    public void Remove()
    {
        m_name = "";
        m_weight = 0;
    }
}
