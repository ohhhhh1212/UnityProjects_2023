using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    public Text m_result = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;

    Dictionary<int, string> m_dic = new Dictionary<int, string>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
    }

    void OnClicked_OK()
    {
        m_result.text = string.Empty;
        m_dic.Clear();

        m_dic.Add(1, "사과");
        m_dic.Add(2, "배");
        m_dic.Add(3, "수박");
        m_result.text += "[Dictionary - KeyValuePair]\n";
        PrintDic();

        m_result.text += "[값 변경] -------------------------------\n";
        m_result.text += "1 : 맛있는 사과, 2 : 맛있는 배\n\n";
        m_dic[1] = "맛있는 사과";
        m_dic[2] = "맛있는 배";

        m_result.text += "[삭제]---------------------------------\n";
        m_dic.Remove(1);
        PrintDic();
    }

    void OnClicked_Cancel()
    {
        m_result.text = "result";
    }

    void PrintDic()
    {
        string str = string.Empty;
        foreach (KeyValuePair<int, string> item in m_dic)
        {
            str += string.Format("{0} : {1}, ", item.Key, item.Value);
        }
        str += "\n\n";
        m_result.text += str;
    }
}
