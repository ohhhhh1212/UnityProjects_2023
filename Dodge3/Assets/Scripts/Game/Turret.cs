using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform m_body = null;
    [SerializeField] GameObject m_bulletPre = null;
    [SerializeField] Transform m_bulletPos = null;
    Transform m_bulletList = null;
    Transform m_target = null;
    AudioSource m_shootSound = null;
    bool isBomb = false;
    bool m_isSFX = false;

    private void Update()
    {
        if (m_body == null)
            return;

        m_body.LookAt(m_target);
    }

    public void Init(Transform target, Transform bullList)
    {
        m_target = target;
        m_bulletList = bullList;
        m_shootSound = GetComponent<AudioSource>();
        m_isSFX = GameMgr.Inst.isSFX;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(m_bulletPre, m_bulletPos.position, Quaternion.identity, m_bulletList);
        bullet.GetComponent<Bullet>().Init(m_target);

        if(m_isSFX)
            m_shootSound.Play();
    }

    IEnumerator Co_Shoot()
    {
        while (GameMgr.Inst.battleFSM.IsGameState() && !isBomb)
        {
            Shoot();

            yield return new WaitForSeconds(GameMgr.Inst.gameInfo.m_FireDelayTime);
        }
    }

    public void StartShoot()
    {
        StartCoroutine(Co_Shoot());
    }

    IEnumerator Co_PauseShoot(float time)
    {
        isBomb = true;

        yield return new WaitForSeconds(time);

        isBomb = false;
        StartShoot();
    }

    public void PauseShoot(float time)
    {
        StartCoroutine(Co_PauseShoot(time));
    }

}
