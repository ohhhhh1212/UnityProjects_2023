using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public InputField m_inputName = null;
    public InputField m_inputWeight = null;
    public Text m_txtResult = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;
    public Button m_btnAdd = null;

    int m_cnt = 0;
    List<Monster> monsters = new List<Monster>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_OK()
    {
        m_txtResult.text = string.Empty;
        monsters.Sort((a, b) => a.m_hp > b.m_hp ? 1 : -1);

        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].SetHp(80);
            m_txtResult.text += $"{i+1} Name = {monsters[i].m_name}, Hp = {monsters[i].m_hp}\n";
        }
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        m_cnt = 0;
        monsters.Clear();
    }

    void OnClicked_Add()
    {
        if (m_cnt > 3)
            print("범위를 벗어남");

        Monster monster = new Monster(m_inputName.text, int.Parse(m_inputWeight.text));
        monsters.Add(monster);
    }
}
