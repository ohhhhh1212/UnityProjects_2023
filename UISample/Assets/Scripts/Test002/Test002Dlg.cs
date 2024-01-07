using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public InputField m_InputHour = null;
    public InputField m_InputMin = null;
    public Text m_Result = null;
    public Button btnOK = null;
    public Button btnCancel = null;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        btnOK.onClick.AddListener(OnClicked_OK);
        btnCancel.onClick.AddListener(OnClicked_Cancel);
    }

    public void OnClicked_OK()
    {
        //int score = int.Parse(m_Input.text);
        //Test_If(score);
        //Test_Switch(score);

        CalTime();
    }

    public void OnClicked_Cancel()
    {
        m_Result.text = "";
    }

    void Test_If(int score)
    {
        string rank = string.Empty;

        if (score >= 90)
            rank = "A";
        else if (score >= 80)
            rank = "B";
        else if (score >= 70)
            rank = "C";
        else if (score >= 60)
            rank = "D";
        else
            rank = "F";

        m_Result.text = rank;
    }

    void Test_Switch(int score)
    {
        string rank = string.Empty;

        switch (score)
        {
            case >= 90:
                rank = "A";
                break;
            case >= 80:
                rank = "B";
                break;
            case >= 70:
                rank = "C";
                break;
            case >= 60:
                rank = "D";
                break;
            default:
                rank = "F";
                break;
        }

        m_Result.text = rank;
    }

    void CalTime()
    {
        int hour = int.Parse(m_InputHour.text);
        int min = int.Parse(m_InputMin.text);

        if (min - 30 >= 0)
            min -= 30;
        else
        {
            if (hour > 0)
                hour--;
            else
                hour = 23;

            min = 60 + (min - 30);
        }

        m_Result.text = $"{hour} : {min}";
    }
}
