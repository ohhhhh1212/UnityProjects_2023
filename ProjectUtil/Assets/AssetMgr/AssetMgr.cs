using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetWave
{
    public int wave = 0;
    public int monsterCount = 0;
    public float spawnDelay = 0;
    public int sMonsterHp = 0;
    public int fMonsterHp = 0;
}

public class AssetPlayer
{
    public int playerLevel = 0;
    public int maxExp = 0;
    public int Hp = 0;
    public int attack = 0;
}

public class AssetSkill
{
    public int level = 0;
    public int count = 0;
    public float damage = 0;
    public float delay = 0f;
    public float speed = 0;
}

public class AssetMgr
{
    static AssetMgr _Inst = null;
    public static AssetMgr Inst
    {
        get
        {
            if (_Inst == null)
                _Inst = new AssetMgr();
            return _Inst;
        }
    }
    private AssetMgr() { }

    public List<AssetWave> m_WaveInfos = new List<AssetWave>();
    public List<AssetPlayer> m_PlayerInfos = new List<AssetPlayer>();
    public List<List<AssetSkill>> m_SkillInfos = new List<List<AssetSkill>>();

    public void Initialize()
    {
        //InitWave("TableData/WaveInfo");
        //InitPlayer("TableData/PlayerInfo");
        InitSkill("TableData/SkillInfo");
    }

    void InitWave(string pathName)
    {
        m_WaveInfos.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null) return;
        for (int i = 1; i < datas.Count; i++)
        {
            string[] aStr = datas[i];
            AssetWave waveInfo = new AssetWave();
            int idx = 0;
            waveInfo.wave = int.Parse(aStr[idx++]);
            waveInfo.monsterCount = int.Parse(aStr[idx++]);
            waveInfo.spawnDelay = float.Parse(aStr[idx++]);
            waveInfo.sMonsterHp = int.Parse(aStr[idx++]);
            waveInfo.fMonsterHp = int.Parse(aStr[idx++]);

            m_WaveInfos.Add(waveInfo);
        }
        datas.Clear();
    }

    void InitPlayer(string pathName)
    {
        m_PlayerInfos.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null) return;
        for (int i = 1; i < datas.Count; i++)
        {
            string[] aStr = datas[i];
            AssetPlayer playerInfo = new AssetPlayer();
            int idx = 0;
            playerInfo.playerLevel = int.Parse(aStr[idx++]);
            playerInfo.maxExp = int.Parse(aStr[idx++]);
            playerInfo.Hp = int.Parse(aStr[idx++]);
            playerInfo.attack = int.Parse(aStr[idx++]);
            m_PlayerInfos.Add(playerInfo);
        }
        datas.Clear();
    }

    void InitSkill(string pathName)
    {
        m_SkillInfos.Clear();

        for (int i = 1; i < 7; i++)
        {
            string path = $"{pathName}{i}";
            List<string[]> datas = CSVParser.Load(path);
            if (datas == null) return;

            List<AssetSkill> listSkill = new List<AssetSkill>();

            for (int j = 1; j < datas.Count; j++)
            {
                string[] aStr = datas[j];
                AssetSkill skillInfo = new AssetSkill();
                int idx = 0;
                skillInfo.level = int.Parse(aStr[idx++]);
                skillInfo.count = int.Parse(aStr[idx++]);
                skillInfo.damage = float.Parse(aStr[idx++]);
                skillInfo.delay = float.Parse(aStr[idx++]);
                skillInfo.speed = float.Parse(aStr[idx++]);

                listSkill.Add(skillInfo);
            }

            m_SkillInfos.Add(listSkill);
            datas.Clear();
        }
    }
}
