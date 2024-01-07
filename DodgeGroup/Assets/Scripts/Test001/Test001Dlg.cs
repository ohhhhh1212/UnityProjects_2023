using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test001Dlg : MonoBehaviour
{
    [SerializeField] Player m_player = null;
    [SerializeField] Turret m_turret = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_turret.Shot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(5);
    }

}
