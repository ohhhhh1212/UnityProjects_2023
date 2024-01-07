using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test04Scene : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Text m_txtCount = null;
    [SerializeField] GameObject m_pnlMain = null;
    [SerializeField] GameObject m_pnlGame = null;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(5);
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
    }

    void OnClicked_Start()
    {
        StartCoroutine(Co_Count());
    }

    IEnumerator Co_Count()
    {
        m_pnlMain.SetActive(false);
        m_pnlGame.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            m_txtCount.text = $"{i}";
            yield return Co_Size();
        }

        m_txtCount.text = "Start!";
        yield return new WaitForSeconds(1f);
        m_pnlGame.SetActive(false);
    }

    Vector3 m_Start = new Vector3(3,3,3);
    Vector3 m_End = new Vector3(1, 1, 1);
    IEnumerator Co_Size()
    {
        bool bCheck = true;
        float t = 0;
        while (bCheck)
        {
            Vector3 v = Vector3.Lerp(m_Start, m_End, t);
            m_txtCount.transform.localScale = v;
            t += 0.1f;
            if (t >= 1.0f)
                bCheck = false;

            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
