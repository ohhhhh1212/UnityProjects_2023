using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPatternTest : MonoBehaviour
{
    void Start()
    {
        GameMgr2.Inst.Init();
    }

}
