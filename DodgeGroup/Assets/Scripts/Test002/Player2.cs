using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float m_playerSpeed = 3f;
    [SerializeField] ParticleSystem m_nuke = null;
    [SerializeField] AudioSource m_bomb = null;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z).normalized;
        transform.Translate(dir * Time.deltaTime * m_playerSpeed, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            m_nuke.gameObject.SetActive(true);
            m_nuke.Play();
            m_bomb.Play();
        }
    }
}
