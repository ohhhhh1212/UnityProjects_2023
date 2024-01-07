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

    // UI Event 등록 시키는 방법
    // OnEnable() -> 등록
    // OnDisable() -> 해제
    
    [System.Serializable]
    public class TextInfo
    {
        // Text 컴포넌트
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
        // UI Event 등록 방법
        // [UI 컴포넌트 변수].[해당 컴포넌트의 이벤트 이름].AddListener([등록할 함수]);
        // UI Event 해제 방법 
        // [UI 컴포넌트 변수].[해당 컴포넌트의 이벤트 이름].RemoveListener([등록한 함수]);

        // Toggle Event 등록
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
