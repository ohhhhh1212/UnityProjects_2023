using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public InputField m_inputName = null;
    public InputField m_inputWeight = null;
    public Text m_txtResult = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;
    public Button m_btnAdd = null;

    int m_cnt = 0;
    Animal animal1 = new Animal();
    Animal animal2 = new Animal();

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
        int tot = animal1.m_weight + animal2.m_weight;
        m_txtResult.text = $"{animal1.m_name}와 {animal2.m_name}의 무게는 {tot}kg 입니다.";
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        m_cnt = 0;
        animal1.Remove();
        animal2.Remove();
    }

    void OnClicked_Add()
    {
        if (m_cnt == 0)
        {
            animal1.Setting(m_inputName.text, int.Parse(m_inputWeight.text));
            m_cnt++;
        }
        else if (m_cnt == 1)
            animal2.Setting(m_inputName.text, int.Parse(m_inputWeight.text));
        else
            print("범위를 벗어남");
    }
}
