using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Button btn_OK = null;
    public Button btn_Cancel = null;
    public Text result = null;

    int[] temp = { 100, 200, 300};

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_OK.onClick.AddListener(OnClicked_OK);
        btn_Cancel.onClick.AddListener(OnClicked_Cancel);
    }

    public void OnClicked_OK()
    {
        result.text = string.Empty;
        Test_for();
        Test_foreach();
        Test_while();
        Test_dowhile();
    }

    public void OnClicked_Cancel()
    {
        result.text = "result";
    }

    void Test_for()
    {
        for (int i = 0; i < temp.Length; i++)
        {
            result.text += string.Format("Temp[{0}] = {1}\n", i, temp[i]);
        }
        result.text += "\n";
    }

    void Test_foreach()
    {
        int cnt = 0;
        foreach (int num in temp)
        {
            result.text += string.Format("Temp[{0}] = {1}\n", cnt, num);
            cnt++;
        }
        result.text += "\n";
    }

    void Test_while()
    {
        int cnt = 0;
        while(cnt < temp.Length)
        {
            result.text += string.Format("Temp[{0}] = {1}\n", cnt, temp[cnt]);
            cnt++;
        }
        result.text += "\n";
    }

    void Test_dowhile()
    {
        int cnt = 0;
        do
        {
            result.text += string.Format("Temp[{0}] = {1}\n", cnt, temp[cnt]);
            cnt++;
        } while (cnt < temp.Length);
        result.text += "\n";
    }
}
