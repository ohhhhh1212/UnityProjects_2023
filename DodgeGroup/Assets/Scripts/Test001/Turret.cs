using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform m_body = null;
    [SerializeField] Transform m_bulletPos = null;
    [SerializeField] GameObject m_preBullet = null;
    [SerializeField] Transform m_target = null;
    [SerializeField] Transform m_bulletParent = null;

    private void Update()
    {
        m_body.LookAt(m_target);
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(m_preBullet, m_bulletParent.transform);
        bullet.transform.position = m_bulletPos.position;
        Bullet kBullet = bullet.GetComponent<Bullet>();
        kBullet.Initialize(m_target);
    }

}
