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
    public GameInfo gameInfo = new GameInfo();
    public SaveInfo saveInfo = new SaveInfo();

    public bool isSFX = false;
    public int curStage = 1;
    public int curScore = 0;
    int bonusScore = 0;
    

    public int GetAccumScore()
    {
        return saveInfo.AccumScore;
    }

    public void AddScoreList()
    {
        CalScore();

        saveInfo.scoreList.Add(curScore);
        saveInfo.AccumScore += curScore;
    }

    void CalScore()
    {
        curScore = gameInfo.m_PlayerHp + bonusScore * 5;

        if (curScore < 20)
            curScore = 20;
    }

    public void SetBonusScore(int i)
    {
        bonusScore += i;
    }
}
