using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTestDlg : MonoBehaviour
{
    private void Start()
    {
        //print("Score1 = " + CGameManager.Inst.m_Score);
        //CGameManager.Inst.Initialize();
        //print("Score2 = " + CGameManager.Inst.m_Score);

        GameMgr.Inst.Initialize();
        print(GameMgr.Inst.m_Name);
    }
}
