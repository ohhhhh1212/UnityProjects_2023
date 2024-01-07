using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public Text m_txt = null;

    public void Init(string s)
    {
        if(m_txt == null)
            m_txt = GetComponent<Text>();

        m_txt.text = s;
    }

}
