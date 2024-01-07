using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [SerializeField] Player3 m_player = null;
    [SerializeField] Turret3[] m_turret = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(5);
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }

    void OnClicked_Start()
    {
        for (int i = 0; i < m_turret.Length; i++)
        {
            m_turret[i].StartShot();
        }
    }

    void OnClicked_Stop()
    {
        for (int i = 0; i < m_turret.Length; i++)
        {
            m_turret[i].StopShot();
        }
    }

}
