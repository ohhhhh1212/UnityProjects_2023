using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene02 : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Player2 m_player = null;
    [SerializeField] Turret2 m_turret = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_turret.Shot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(5);
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }


    void OnClicked_Start()
    {
        m_turret.StartShot();
    }

    void OnClicked_Stop()
    {
        m_turret.StopShot();
    }

}
