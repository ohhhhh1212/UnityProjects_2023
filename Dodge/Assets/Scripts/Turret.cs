using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject m_preBullet = null;
    [SerializeField] Transform m_target = null;
    [SerializeField] Transform m_bullets = null;
    [SerializeField] Transform m_bulletPos = null;
    [SerializeField] Transform m_body = null;

    bool m_isShot = false;

    private void Update()
    {
        m_body.LookAt(m_target);
    }

    public void StartShot()
    {
        m_isShot = true;
        StartCoroutine(Co_Shot());
    }

    public void StopShot()
    {
        m_isShot = false;
    }

    IEnumerator Co_Shot()
    {
        while (m_isShot)
        {
            Shot();
            yield return new WaitForSeconds(2f);
        }
    }

    void Shot()
    {
        GameObject go = Instantiate(m_preBullet, m_bulletPos.position, Quaternion.identity, m_bullets);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.Init(3f, m_target);
    }
}
