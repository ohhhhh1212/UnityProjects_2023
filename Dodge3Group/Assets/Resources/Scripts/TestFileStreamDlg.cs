using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestFileStreamDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    int i = 0;
    float f = 0f;
    double d = 0f;
    string s = "";


    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Save()
    {
        i = 100;
        f = 123.34f;
        d = 456789.1234f;
        s = "cafe.naver.com";

        FileStream fs = new FileStream("save.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(i);
        bw.Write(f);
        bw.Write(d);
        bw.Write(s);

        fs.Close();
        bw.Close();

        m_txtResult.text = "save.data에 저장 되었습니다.";
    }

    void OnClicked_Load()
    {
        try
        {
            FileStream fs = new FileStream("save.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            i = br.ReadInt32();
            f = br.ReadSingle();
            d = br.ReadDouble();
            s = br.ReadString();

            fs.Close();
            br.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }

        m_txtResult.text = $"i = {i}\nf = {f}\nd = {d}\nstr = {s}";
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "초기화 되었습니다.";
    }

}
