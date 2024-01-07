using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test006Dlg : MonoBehaviour
{
    [SerializeField] Button[] btnTest = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < btnTest.Length; i++)
        {
            int idx = i;
            btnTest[i].onClick.AddListener(() => OnClicked_Test(idx));
        }
    }

    void OnClicked_Test(int idx)
    {
        SceneManager.LoadScene(idx);
    } 

}
