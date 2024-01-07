using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SStage
{
    public int stage;
    public int score;

    public SStage(int s, int i)
    {
        stage = s;
        score = i;
    }
}

public class SaveInfoTestDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    List<SStage> m_StageList = new List<SStage>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        SStage stage1 = new SStage(1, 1200);
        SStage stage2 = new SStage(2, 650);
        SStage stage3 = new SStage(3, 930);

        m_StageList.Add(stage1);
        m_StageList.Add(stage2);
        m_StageList.Add(stage3);
    }

    void OnClicked_Save()
    {
        FileStream fs = new FileStream("SaveInfo.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(m_StageList.Count);

        for (int i = 0; i < m_StageList.Count; i++)
        {
            bw.Write(m_StageList[i].stage);
            bw.Write(m_StageList[i].score);
        }

        fs.Close();
        bw.Close();

        m_txtResult.text = "SaveInfo.data에 저장 되었습니다.";
    }

    void OnClicked_Load()
    {
        try
        {
            m_StageList.Clear();

            FileStream fs = new FileStream("SaveInfo.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int high = 0;
            int tot = 0;

            int n = br.ReadInt32();

            for (int i = 0; i < n; i++)
            {
                SStage stage = new SStage(br.ReadInt32(), br.ReadInt32());

                if (high < stage.score)
                    high = stage.score;

                tot += stage.score;

                m_StageList.Add(stage);
            }

            string str = $"HighScore : {high}\nAccumulateScore : {tot}\nLastStage : {n}\n";
            for (int i = 0; i < m_StageList.Count; i++)
            {
                str += $"{m_StageList[i].stage} stage : {m_StageList[i].score}\n";
            }

            m_txtResult.text = str;

            fs.Close();
            br.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }

    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "초기화 되었습니다.";
    }
}
