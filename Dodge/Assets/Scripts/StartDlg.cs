using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDlg : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;


    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
    }

    void OnClicked_Start()
    {
        GameMgr.Inst.battleFSM.SetWaveState();
    }
}
