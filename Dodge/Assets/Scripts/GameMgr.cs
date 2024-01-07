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
    private GameMgr() { }

    public BattleFSM battleFSM = new BattleFSM();

    public float time = 0f;
    public int min
    {
        get { return (int)(time / 60); }
    }
    public int sec
    {
        get { return (int)(time % 60); }
    }

    public void Init()
    {
        time = 0f;
    }

    public void CalTime()
    {
        time += Time.deltaTime;
    }
}
