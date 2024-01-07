using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudUI : MonoBehaviour
{
    public ReadyUI m_ReadyUI = null;
    public GamingUI m_GamingUI = null;
    public ResultUI m_ResultUI = null;

    public void Init()
    {
        m_ReadyUI.Init();
        m_GamingUI.Init();
        m_ResultUI.Init();
    }
}
