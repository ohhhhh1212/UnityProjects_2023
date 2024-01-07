using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDlg : MonoBehaviour
{
    public Text m_txtResultTime = null;
    public Button m_btnReStart = null;
    public Button m_btnExit = null;

    void Init()
    {
        m_btnReStart.onClick.AddListener(OnClicked_Restart);
        m_btnExit.onClick.AddListener(OnClicked_Exit);
    }

    void OnClicked_Restart()
    {
        GameMgr.Inst.battleFSM.SetWaveState();
    }

    void OnClicked_Exit()
    {
        GameMgr.Inst.battleFSM.SetReadyState();
    }


}
