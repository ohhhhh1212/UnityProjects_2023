using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour
{
    [SerializeField] Text m_txtCount = null;

    public void Init()
    {
        gameObject.SetActive(true);
        StartCoroutine(Co_Count());
    }



    IEnumerator Co_Count()
    {
        for (int i = 3; i > 0; i--)
        {
            m_txtCount.text = $"{i}";
            yield return new WaitForSeconds(1f);
        }

        m_txtCount.text = "Start";
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);

        GameMgr.Inst.battleFSM.SetGameState();
    }
}
