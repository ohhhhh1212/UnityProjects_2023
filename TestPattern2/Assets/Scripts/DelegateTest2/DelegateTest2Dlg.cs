using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest2Dlg : MonoBehaviour
{
    [SerializeField] Image m_img = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnReset = null;
    [SerializeField] MyButton m_myBtn = null;


    private void Start()
    {
        Init();
    }

    void Init()
    {
        //m_myBtn = m_img.GetComponent<MyButton>();
        m_myBtn.OnAddListner(OnClicked_Btn);
        m_btnReset.onClick.AddListener(OnClicked_Reset);
    }

    void OnClicked_Btn()
    {
        m_txtResult.text = "¹öÆ° ¼±ÅÃµÊ";
    }

    void OnClicked_Reset()
    {
        m_txtResult.text = "";
    }
}
