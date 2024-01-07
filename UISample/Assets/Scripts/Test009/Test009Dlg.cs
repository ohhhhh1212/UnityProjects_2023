using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    public InputField m_inputName = null;
    public InputField m_inputWeight = null;
    public Text m_txtResult = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;
    public Button m_btnAdd = null;

    Animal animal = new Animal();

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
        m_txtResult.text = $"{animal.m_name}의 무게는 {animal.m_weight}kg 입니다.";
    }

    void OnClicked_Cancel()
    {
        m_txtResult.text = "result";
        animal.Remove();
    }

    void OnClicked_Add()
    {
        animal.Setting(m_inputName.text, int.Parse(m_inputWeight.text));
    }
}
