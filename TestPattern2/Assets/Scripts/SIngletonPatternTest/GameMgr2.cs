using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr2 : MonoBehaviour
{
    static GameMgr2 _inst = null;
    public static GameMgr2 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject go = new GameObject("GameMgr2");
                _inst = go.AddComponent<GameMgr2>();
                DontDestroyOnLoad(go);
            }

            return _inst;
        }
    }

    private GameMgr2() { }

    public void Init()
    {

    }
}
