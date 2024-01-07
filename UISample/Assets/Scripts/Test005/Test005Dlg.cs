using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Text result = null;
    public Button btn_OK = null;
    public Button btn_Cancel = null;

    List<int> list = new List<int>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_OK.onClick.AddListener(OnClicked_OK);
        btn_Cancel.onClick.AddListener(OnClicked_Cancel);
    }

    void OnClicked_OK()
    {
        list.Clear();
        result.text = string.Empty;
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Test_for();

        list.Add(40);
        list.Add(50);

        Test_foreach();

        list.Remove(10);
        list.Remove(40);

        Test_foreach();
    }

    void OnClicked_Cancel()
    {
        result.text = "result";
    }

    void Test_for()
    {
        string str = "[리스트 - for]\n";
        for (int i = 0; i < list.Count; i++)
        {
            str += string.Format("[{0}]: {1}, ", i, list[i]);
        }
        str += "\n\n";
        result.text += str;
    }

    void Test_foreach()
    {
        string str = "[리스트 - foreach]\n";
        for (int i = 0; i < list.Count; i++)
        {
            str += string.Format("{0}, ", list[i]);
        }
        str += "\n\n";
        result.text += str;
    }

}
