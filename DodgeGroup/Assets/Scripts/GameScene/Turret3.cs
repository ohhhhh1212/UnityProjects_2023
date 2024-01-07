using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    [SerializeField] Transform m_target = null;
    [SerializeField] Transform m_body = null;
    [SerializeField] GameObject m_preBullet = null;
    [SerializeField] Transform m_bulletPos = null;
    [SerializeField] Transform m_bulletParent = null;

    bool m_isShot = false;
    float m_delay = 1.2f;


    private void Update()
    {
        m_body.transform.LookAt(m_target);
    }

    public void StartShot()
    {
        StopAllCoroutines();
        StartCoroutine(Co_Shot(m_delay));
        m_isShot = true;
    }

    public void StopShot()
    {
        m_isShot = false;
    }

    IEnumerator Co_Shot(float delay)
    {
        while (m_isShot)
        {
            Shot();
            yield return new WaitForSeconds(delay);
        }
    }

    void Shot()
    {
        GameObject bullet = Instantiate(m_preBullet, m_bulletPos.position, Quaternion.identity, m_bulletParent);
        Bullet3 bull = bullet.GetComponent<Bullet3>();
        bull.Init(m_target);
    }

}
