using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObjDlg : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] ItemObjMgr ItemMgr = null;

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
        StartCoroutine(ItemMgr.Co_ItemSpawn());
        m_txtResult.text = "Spawning...";
    }

    void OnClicked_Stop()
    {
        ItemMgr.Stop_ItemSpawn();
        m_txtResult.text = "Stop";
    }


}
