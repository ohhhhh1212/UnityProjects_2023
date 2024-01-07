using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_UIManager_01 : MonoBehaviour
{
    [SerializeField]
    Text txt_ID;

    [SerializeField]
    Text txt_Name;

    [SerializeField]
    Toggle toggle_Check;

    // UI Event ��� ��Ű�� ���
    // OnEnable() -> ���
    // OnDisable() -> ����
    
    [System.Serializable]
    public class TextInfo
    {
        // Text ������Ʈ
        public Text txt;

        public int fontSize;
        public FontStyle fontStyle;
        public Color fontColor;

        public void SetText()
        {
            txt.fontSize = fontSize;
            txt.fontStyle = fontStyle;
            txt.color = fontColor;
        }
    }

    [SerializeField]
    TextInfo[] toggleOn;
    [SerializeField]
    TextInfo[] toggleOff;

    void Start()
    {
        // UI Event ��� ���
        // [UI ������Ʈ ����].[�ش� ������Ʈ�� �̺�Ʈ �̸�].AddListener([����� �Լ�]);
        // UI Event ���� ��� 
        // [UI ������Ʈ ����].[�ش� ������Ʈ�� �̺�Ʈ �̸�].RemoveListener([����� �Լ�]);

        // Toggle Event ���
        toggle_Check.onValueChanged.AddListener(Event_ToggleCheck);
    }

    void Event_ToggleCheck(bool value)
    {
        if (value)
        {
            SetText(txt_ID, 150, FontStyle.Bold, Color.red);
            SetText(txt_Name, 100, FontStyle.Normal, Color.white);
        }
        else
        {
            for (int i = 0; i < toggleOff.Length; i++)
            {
                toggleOff[i].SetText();
            }
        }
    }

    void SetText(Text txt, int size, FontStyle style, Color color)
    {
        txt.fontSize = size;
        txt.fontStyle = style;
        txt.color = color;
    }
}
