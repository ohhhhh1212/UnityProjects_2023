using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor
{
    int m_HP = 0;
    int m_Attack = 0;

    public void AddHp(int h)
    {
        m_HP += h;
    }

    public void SetDamage(int d)
    {
        m_HP -= d;
    }

    public void Set(int h, int d)
    {
        m_HP = h;
        m_Attack = d;
    }

    public int GetHP()
    {
        return m_HP;
    }

    public int GetAttack()
    {
        return m_Attack;
    }

    public Actor(int h, int d)
    {
        m_HP = h;
        m_Attack = d;
    }
}


public class Test008Dlg : MonoBehaviour
{
    public Text m_txtresult = null;
    public Button m_btnOK = null;
    public Button m_btnCancel = null;

    Actor m_Player = new Actor(5000, 200);
    Actor m_Enemy = new Actor(2000, 200);

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnCancel.onClick.AddListener(OnClicked_Cancel);
    }

    void OnClicked_OK()
    {
        string str = string.Empty;

        m_Player.Set(5000, 100);
        str += $"[기본 HP={m_Player.GetHP()}, Attack={m_Player.GetAttack()}]\nMaster HP = {m_Player.GetHP()}\n";

        m_Player.SetDamage(50);
        str += $"[데미지 50 생김]\nMaster HP = {m_Player.GetHP()}\n";
        str += "------------------------------------------------\n";

        m_Enemy.Set(2000, 200);
        str += $"적 HP={m_Enemy.GetHP()}, Attack={m_Enemy.GetAttack()} 으로 설정\nEnemy HP = {m_Enemy.GetHP()}\n";

        m_Enemy.SetDamage(100);
        str += $"[적이 마스터에게 공격 당함]\nEnemy HP = {m_Enemy.GetHP()}\n";
        str += "------------------------------------------------\n";

        m_Player.AddHp(100);
        str += $"[마스터가 HP 100만큼 힐링이 됨]\nMaster HP = {m_Player.GetHP()}\n";

        m_Enemy.AddHp(200);
        str += $"[적의 HP 200만큼 힐링이 됨]\nEnemy HP = {m_Enemy.GetHP()}\n";
        str += "-------------------------------------------------";

        m_txtresult.text = str;
    }

    void OnClicked_Cancel()
    {
        m_txtresult.text = "result";
    }

}


