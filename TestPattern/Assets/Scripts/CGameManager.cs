using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    static CGameManager _inst = null;

    public static CGameManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject go = new GameObject();

                _inst = go.AddComponent<CGameManager>();
                DontDestroyOnLoad(go);

                go.name = "<=GameManager=>";
            }

            return _inst;
        }
    }


    public int m_Score = 200;
    public void Initialize()
    {
        m_Score = 300;
    }
}
