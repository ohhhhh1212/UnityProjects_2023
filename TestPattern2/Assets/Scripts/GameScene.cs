using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    private BattleFSM m_BattleFSM = new BattleFSM();

    [SerializeField] Text m_txtHp = null;
    [SerializeField] Text m_txtState = null;
    [SerializeField] Text m_txtTime = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Button m_btnAttack = null;

    float t = 0;
    int m_hp = 100;
    bool m_isGame = false;

    private void Awake()
    {
        m_BattleFSM.Initialize(OnEnter_ReadyState, OnEnter_WaveState, OnEnter_GameState, OnEnter_ResultState);
    }

    private void Update()
    {
        if (m_BattleFSM != null)
            m_BattleFSM.OnUpdate();

        if (m_isGame)
        {
            t += Time.deltaTime;
            m_txtTime.text = $"time : {t:0.00}";

            if (t >= 20f)
            {
                m_txtState.text = "Result (ÆÐ)";
                m_BattleFSM.SetResultState();
            }
        }
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_btnAttack.onClick.AddListener(OnClicked_Attack);
    }

    void OnClicked_Start()
    {
        OnEnter_ReadyState();
        StartCoroutine(Co_GameState());
    }

    void OnClicked_Stop()
    {
        m_BattleFSM.SetNoneState();
        m_isGame = false;
    }

    void OnClicked_Attack()
    {
        m_hp -= 10;

        if (m_hp  <= 0)
        {
            m_txtState.text = "Result (½Â)";
            m_txtHp.text = $"0";
            m_BattleFSM.SetResultState();
        }

        m_txtHp.text = $"Monster HP = {m_hp}";
    }

    void OnEnter_ReadyState()
    {
        t = 0;
        m_hp = 100;
        m_txtHp.text = $"Monster HP = {m_hp}";
        m_txtTime.text = $"time : {t:0.00}";
        m_txtState.text = "Ready";
    }
    void OnEnter_WaveState()
    {

    }
    void OnEnter_GameState()
    {
        m_txtState.text = "Game";
    }
    void OnEnter_ResultState()
    {
        m_isGame = false;
    }

    IEnumerator Co_GameState()
    {
        yield return new WaitForSeconds(1f);

        m_isGame = true;
        OnEnter_GameState();
    }
}
