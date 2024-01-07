using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem
{
    public int m_id = 0;
    public string m_name = string.Empty;
    public int m_value = 0;
}


public class CSVParserTestUI : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnParsing = null;
    [SerializeField] Button m_btnClear = null;

    List<string[]> listDatas = new List<string[]>();
    List<TestItem> listItems = new List<TestItem>();


    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        //m_btnParsing.onClick.AddListener(OnClicked_Parsing);
        m_btnParsing.onClick.AddListener(ParsingTest);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Load()
    {
        listDatas = CSVParser.Load("TableData/test");
        //listDatas = CSVParser.Load2("Assets/Resources/TableData/test.csv");

        string str = string.Empty;
        for (int i = 0; i < listDatas.Count; i++)
        {
            for (int j = 0; j < listDatas[i].Length; j++)
            {
                str += $"{listDatas[i][j]} ";
            }
            str += "\n";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Parsing()
    {
        if(listDatas.Count == 0)
        {
            print("저장된 것이 없습니다.");
            return;
        }

        string str = string.Empty;

        for (int i = 1; i < listDatas.Count; i++)
        {
            str += $"{listDatas[i][0]}, {listDatas[i][1]}, {listDatas[i][2]}\n";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        listDatas.Clear();
        m_txtResult.text = "Result";
    }

    void ParsingTest()
    {
        for (int i = 1; i < listDatas.Count; i++)
        {
            TestItem item = new TestItem();
            string[] datas = listDatas[i];
            item.m_id = int.Parse(datas[0]);
            item.m_name = datas[1];
            item.m_value = int.Parse(datas[2]);

            listItems.Add(item);
        }

        string str = string.Empty;

        for (int i = 1; i < listItems.Count; i++)
        {
            int id = listItems[i].m_id;
            string name = listItems[i].m_name;
            int value = listItems[i].m_value;
            str += $"{id}, {name}, {value}\n";
        }

        m_txtResult.text = str;
    }

    void PrintItem()
    {
        string str = string.Empty;

        for (int i = 1; i < listDatas.Count; i++)
        {
            for (int j = 0; j < listDatas[i].Length; j++)
            {
                if (j == listDatas[i].Length - 1)
                {
                    str += $"{listDatas[i][j]}";
                    break;
                }

                str += $"{listDatas[i][j]}, ";
            }
            str += "\n";
        }

        m_txtResult.text = str;
    }
}
