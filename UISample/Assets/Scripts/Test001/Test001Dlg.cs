using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    public Text m_Result = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;

    int a = 100;
    int b = 200;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
    }

    public void OnClicked_OK()
    {
        string txt = $"a = {a}, b = {b}\n";
        Swap(ref a, ref b);
        txt += $"a = {a}, b = {b}";
        m_Result.text = txt;
    }

    public void OnClicked_Cancel()
    {
        m_Result.text = "";
    }

    void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }

}
