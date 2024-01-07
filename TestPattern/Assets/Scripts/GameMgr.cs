using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    static GameMgr _inst = null;
    public static GameMgr Inst
    {
        get
        {
            if (_inst == null)
                _inst = new GameMgr();

            return _inst;
        }
    }

    //---------------------------------------------------------

    public int m_Score = 10;
    public string m_Name = "";

    private GameMgr() {  }

    public void Initialize()
    {
        m_Name = "±Ç±¸¹ü";
        m_Score = 99;
    }
}