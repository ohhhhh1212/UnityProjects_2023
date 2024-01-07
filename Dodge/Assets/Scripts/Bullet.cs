using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float m_bulletSpeed = 2.5f;
    Vector3 m_dir = Vector3.zero;
    [SerializeField] AudioSource m_audShot = null;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        transform.Translate(m_dir * m_bulletSpeed * Time.deltaTime, Space.World);
    }

    public void Init(float speed, Transform target)
    {
        m_bulletSpeed = speed;
        m_dir = target.position - transform.position;
        m_dir.Normalize();

        transform.LookAt(target);
        m_audShot.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
