using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public InputField[] inputfield = null;
    public Button btn_OK = null;
    public Button btn_Cancel = null;
    public Text result = null;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        btn_OK.onClick.AddListener(OnClicked_OK);
        btn_Cancel.onClick.AddListener(OnClicked_Cancel);
    }

    public void OnClicked_OK()
    {
        int[] input = new int[inputfield.Length];
        for (int i = 0; i < inputfield.Length; i++)
        {
            input[i] = int.Parse(inputfield[i].text);
        }

        int temp = 0;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (input[i] > input[j])
                {
                    temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                }
            }
        }

        string res = string.Format("가장 큰수 : {0}\n", input[0]);
        for (int i = 0; i < input.Length; i++)
        {
            res += string.Format("{0}, ", input[i]);
        }
        result.text = res;
    }

    public void OnClicked_Cancel()
    {
        result.text = "result";
    }

}
