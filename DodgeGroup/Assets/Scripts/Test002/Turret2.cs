using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    [SerializeField] Transform m_body = null;
    [SerializeField] Transform m_bulletPos = null;
    [SerializeField] GameObject m_preBullet = null;
    [SerializeField] Transform m_target = null;
    [SerializeField] Transform m_bulletParent = null;

    bool m_isShot = false;
    float m_shotDelay = 1.0f;


    private void Update()
    {
        m_body.LookAt(m_target);
    }

    public void StartShot()
    {
        m_isShot = true;
        StartCoroutine(Co_Shot(m_shotDelay));
    }

    public void StopShot()
    {
        m_isShot = false;
    }

    IEnumerator Co_Shot(float f)
    {
        while (m_isShot)
        {
            Shot();
            yield return new WaitForSeconds(f);
        }
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(m_preBullet, m_bulletParent.transform);
        bullet.transform.position = m_bulletPos.position;
        Bullet2 kBullet = bullet.GetComponent<Bullet2>();
        kBullet.Initialize(m_target);
    }
}
