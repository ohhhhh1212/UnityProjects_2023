using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    [SerializeField] ParticleSystem m_ptcBomb = null;
    [SerializeField] AudioSource m_soundBomb = null;
    float m_playerSpeed = 5.0f;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z);
        dir.Normalize();
        transform.Translate(dir * m_playerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            m_ptcBomb.gameObject.SetActive(true);
            m_ptcBomb.Play();
            m_soundBomb.Play();
        }
    }
}
