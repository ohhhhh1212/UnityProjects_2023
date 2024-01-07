using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVParser
{
    public static List<string[]> Load(string sPathName)
    {
        List<string[]> listData = new List<string[]>();

        TextAsset kTextAsset = Resources.Load<TextAsset>(sPathName);

        if (kTextAsset == null)
            return null;

        StringReader sr = new StringReader(kTextAsset.text);

        string inputData = sr.ReadLine();
        while (inputData != null)
        {
            string[] datas = inputData.Split('\t');
            if (datas.Length == 0)
                continue;

            listData.Add(datas);

            inputData = sr.ReadLine();
        }
        sr.Close();

        return listData;
    }
}
