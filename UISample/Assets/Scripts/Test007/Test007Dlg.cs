using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public InputField m_inputfield = null;
    public Text m_txtResult = null;
    public Text m_txtNums = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;
    public Button m_btnAdd = null;


    List<int> m_list = new List<int>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_txtNums.text = string.Empty;
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_OK()
    {
        string str = string.Empty;
        //SortList();

        Test_Sort1();
        Test_Sort2();
        Test_Sort3();

        for (int i = 0; i < m_list.Count; i++)
        {
            str += $"{m_list[i]}, ";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Add()
    {
        int i = int.Parse(m_inputfield.text);
        m_txtNums.text += $"{i}, ";
        m_list.Add(i);
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
    }

    void SortList()
    {
        int temp = 0;
        for (int i = 0; i < m_list.Count; i++)
        {
            for (int j = 0; j < m_list.Count; j++)
            {
                if (m_list[i] > m_list[j])
                {
                    temp = m_list[i];
                    m_list[i] = m_list[j];
                    m_list[j] = temp;
                }
            }
        }
    }

    void Test_Sort1()
    {
        m_list.Sort();
    }

    void Test_Sort2()
    {
        m_list.Sort((a, b) => a > b ? 1 : -1);
    }

    void Test_Sort3()
    {
        m_list.Sort((a, b) => a.CompareTo(b));
    }
}
