using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVParser
{
    //sPathName : 폴더가 리소스 하위부터 시작 TableData/test
    public static List<string[]> Load(string sPathName)
    {
        List<string[]> listData = new List<string[]>();

        TextAsset kTextAsset = Resources.Load<TextAsset>(sPathName);

        if (kTextAsset == null)
            return null;

        StringReader _reader = new StringReader(kTextAsset.text);

        string inputData = _reader.ReadLine();
        while(inputData != null)
        {
            string[] datas = inputData.Split('\t');
            if (datas.Length == 0)
                continue;

            listData.Add(datas);

            inputData = _reader.ReadLine();
        }
        _reader.Close();

        return listData;
    }

    // sPathName : 폴더가 Asset부터 시작. Asset/Resources/TableData/test.csv
    public static List<string[]> Load2(string sPathName)
    {
        List<string[]> listData = new List<string[]>();

        StreamReader sr = new StreamReader(sPathName, Encoding.UTF8);
        if (sr == null)
            return null;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] datas = line.Split('\t');
            if (datas.Length == 0)
                continue;

            listData.Add(datas);
        }
        sr.Close();

        return listData;
    }
}
