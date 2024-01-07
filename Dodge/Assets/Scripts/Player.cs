using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem m_ptcBomb = null;
    [SerializeField] AudioSource m_audBomb = null;
    float m_playerSpeed = 5f;

    void Update()
    {
        if (GameMgr.Inst.battleFSM.IsGameState())
            Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        dir.Normalize();

        dir = (dir * m_playerSpeed * Time.deltaTime);

        Vector3 v = new Vector3(Mathf.Clamp(transform.position.x + dir.x, -8f, 8f), 1.5f, Mathf.Clamp(transform.position.z + dir.z, -8f, 8f));
        transform.position = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            m_ptcBomb.gameObject.SetActive(true);
            m_ptcBomb.Play();
            m_audBomb.Play();

            Destroy(other.gameObject);

            GameMgr.Inst.battleFSM.SetResultState();
        }
    }

    public void StopEffects()
    {
        m_ptcBomb.Stop();
        m_audBomb.Stop();
    }
}
