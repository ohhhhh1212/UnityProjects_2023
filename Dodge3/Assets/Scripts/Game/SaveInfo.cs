using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveInfo : MonoBehaviour
{
    public int lastStage = 1;
    public int highScore = 0;
    public int AccumScore = 0;

    public List<int> scoreList = new List<int>();

    public void Save()
    {
        lastStage = GameMgr.Inst.curStage;

        FileStream fs = new FileStream("save.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(lastStage);
        bw.Write(AccumScore);

        bw.Write(scoreList.Count);
        for (int i = 0; i < scoreList.Count; i++)
        {
            bw.Write(scoreList[i]);
        }

        fs.Close();
        bw.Close();
    }

    public void Load()
    {
        if (!File.Exists("save.data"))
        {
            print("¾øÀ½");
            return;
        }

        try
        {
            FileStream fs = new FileStream("save.data", FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            lastStage = bw.ReadInt32();
            AccumScore = bw.ReadInt32();

            int len = bw.ReadInt32();
            for (int i = 0; i < len; i++)
            {
                scoreList.Add(bw.ReadInt32());
            }
            highScore = GetHighScore();

            fs.Close();
            bw.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    int GetHighScore()
    {
        int max = 0;

        for (int i = 0; i < scoreList.Count; i++)
        {
            if (scoreList[i] > max)
                max = scoreList[i];
        }

        return max;
    }

}
