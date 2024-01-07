using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Data{
    public string m_id = "";
    public string m_name = "";
    public int m_kor = 0;
    public int m_eng = 0;
    public int m_math = 0;
    public int tot
    {
        get { return m_kor + m_eng + m_math; }
    }
    public float avg
    {
        get { return (float)tot / 3f; }
    }

    public void Init(string id, string name, int kor, int eng, int math)
    {
        m_id = id;
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;
    }
}

public class ScoreTestDlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] InputField m_inputId = null;
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnFix = null;
    [SerializeField] Button m_btnDelete = null;
    [SerializeField] Button m_btnLoadFile = null;
    [SerializeField] Button m_btnSaveFile = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button[] m_btnInfos = null;

    [SerializeField] GameObject m_preItem = null;

    List<Item> m_itemsList = new List<Item>();
    List<Data> m_datasList = new List<Data>();

    Item m_clickedItem = null;

    string[] m_InfoName = new string[7] { "id", "name", "kor", "eng", "math", "tot", "avg" };

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFix.onClick.AddListener(OnClicked_Fix);
        m_btnDelete.onClick.AddListener(OnClicked_Delete);
        m_btnLoadFile.onClick.AddListener(OnClicked_LoadFile);
        m_btnSaveFile.onClick.AddListener(OnClicked_SaveFile);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        for (int i = 0; i < m_btnInfos.Length; i++)
        {
            string idx = m_InfoName[i];
            m_btnInfos[i].onClick.AddListener(() => OnClicked_Info(idx));
        }
    }

    void OnClicked_Item(Item item)
    {
        ClearItemColor();
        item.m_image.color = Color.yellow;

        m_inputId.text = item.m_id;
        m_inputName.text = item.m_name;
        m_inputKor.text = $"{item.m_kor}";
        m_inputEng.text = $"{item.m_eng}";
        m_inputMath.text = $"{item.m_math}";

        m_clickedItem = item;
    }

    void OnClicked_Add()
    {
        if (!CheckInput())
            return;

        string id = m_inputId.text;
        string name = m_inputName.text;
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);

        if (!CheckId(id))
            return;

        CreateItem(id, name, kor, eng, math);

        ClearInput();
    }

    void OnClicked_Fix()
    {
        if (!CheckInput())
            return;

        string id = m_inputId.text;
        string name = m_inputName.text;
        string kor = m_inputKor.text;
        string eng = m_inputEng.text;
        string math = m_inputMath.text;


        m_clickedItem.Init(id, name, int.Parse(kor), int.Parse(eng), int.Parse(math));
        ClearInput();
    }

    void OnClicked_Delete()
    {
        for (int i = 0; i < m_itemsList.Count; i++)
        {
            if(m_clickedItem.m_id == m_itemsList[i].m_id)
            {
                Destroy(m_itemsList[i].gameObject);
                m_itemsList.RemoveAt(i);
                break;
            }
        }

        ClearInput();
    }

    void OnClicked_Clear()
    {
        for (int i = 0; i < m_itemsList.Count; i++)
            Destroy(m_itemsList[i].gameObject);

        m_itemsList.Clear();
        m_datasList.Clear();
        ClearInput();
        m_clickedItem = null;
        ClearItemColor();
    }

    void OnClicked_Info(string type)
    {
        if(type == "id")
        {
            m_datasList.Sort((a, b) => a.m_id.CompareTo(b.m_id));
        }
        else if(type == "name")
        {
            m_datasList.Sort((a, b) => a.m_name.CompareTo(b.m_name));
        }
        else if(type == "kor")
        {
            m_datasList.Sort((a, b) => b.m_kor.CompareTo(a.m_kor));
        }
        else if (type == "eng")
        {
            m_datasList.Sort((a, b) => b.m_eng.CompareTo(a.m_eng));
        }
        else if (type == "math")
        {
            m_datasList.Sort((a, b) => b.m_math.CompareTo(a.m_math));
        }
        else if (type == "tot")
        {
            m_datasList.Sort((a, b) => b.tot.CompareTo(a.tot));
        }
        else if (type == "avg")
        {
            m_datasList.Sort((a, b) => b.avg.CompareTo(a.avg));
        }

        for (int i = 0; i < m_datasList.Count; i++)
        {
            Data data = m_datasList[i];
            string id = data.m_id;
            string name = data.m_name;
            int kor = data.m_kor;
            int eng = data.m_eng;
            int math = data.m_math;
            m_itemsList[i].Init(id, name, kor, eng, math);
        }
    }

    void OnClicked_SaveFile()
    {
        SaveFile();
    }

    void OnClicked_LoadFile()
    {
        LoadFile();
    }

    void ClearInput()
    {
        m_inputId.text = string.Empty;
        m_inputName.text = string.Empty;
        m_inputKor.text = string.Empty;
        m_inputEng.text = string.Empty;
        m_inputMath.text = string.Empty;
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("ItemInfo.txt");
        sw.WriteLine(m_datasList.Count);

        m_datasList.Sort((a, b) => b.tot.CompareTo(a.tot));

        for (int i = 0; i < m_datasList.Count; i++)
        {
            sw.WriteLine(m_datasList[i].m_id);
            sw.WriteLine(m_datasList[i].m_name);
            sw.WriteLine(m_datasList[i].m_kor);
            sw.WriteLine(m_datasList[i].m_eng);
            sw.WriteLine(m_datasList[i].m_math);
        }

        sw.Close();
    }

    void LoadFile()
    {
        OnClicked_Clear();

        StreamReader sr = new StreamReader("ItemInfo.txt");

        int len = int.Parse(sr.ReadLine());
        for (int i = 0; i < len; i++)
        {
            string id = sr.ReadLine();
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());

            CreateItem(id, name, kor, eng, math);
        }

        sr.Close();
    }

    void CreateItem(string id, string name, int kor, int eng, int math)
    {
        GameObject go = Instantiate(m_preItem, m_scroll.content);
        Item item = go.GetComponent<Item>();
        item.Init(id, name, kor, eng, math);
        item.m_btnItem.onClick.AddListener(() => OnClicked_Item(item));
        m_itemsList.Add(item);

        Data data = new Data();
        data.Init(id, name, kor, eng, math);
        m_datasList.Add(data);
    }

    void ClearItemColor()
    {
        for (int i = 0; i < m_itemsList.Count; i++)
        {
            m_itemsList[i].m_image.color = Color.white;
        }
    }

    bool CheckInput()
    {
        if (m_inputId.text == string.Empty || m_inputName.text == string.Empty)
        {
            print("값을 입력해주세요");
            return false;
        }
        else if (m_inputKor.text == string.Empty || m_inputEng.text == string.Empty || m_inputMath.text == string.Empty)
        {
            print("값을 입력해주세요");
            return false;
        }

        return true;
    }

    bool CheckId(string id)
    {
        for (int i = 0; i < m_itemsList.Count; i++)
        {
            if (m_itemsList[i].m_id == id)
            {
                print("이미 존재하는 학번입니다.");
                return false;
            }
        }

        return true;
    }
}
