using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Turret[] m_turrets = null;
    public Player m_player = null;

    public void Init()
    {
        m_player.transform.position = new Vector3(0f, 1.5f, 0f);
        m_player.StopEffects();
    }
}
