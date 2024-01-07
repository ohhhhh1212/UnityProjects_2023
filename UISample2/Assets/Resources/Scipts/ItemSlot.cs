using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Text m_txtCity = null;
    public Image m_image = null;

    public void Init(string s)
    {
        m_image = GetComponent<Image>();

        m_txtCity.text = s;
    }
}
