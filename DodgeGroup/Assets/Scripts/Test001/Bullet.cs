using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform m_target = null;
    float m_bulletSpeed = 5f;
    Vector3 m_dir = Vector3.zero;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (m_target == null)
            return;

        transform.Translate(m_dir * Time.deltaTime * m_bulletSpeed, Space.World);
    }

    public void Initialize(Transform target)
    {
        m_target = target;
        transform.LookAt(m_target);

        m_dir = m_target.position - transform.position;
        m_dir.Normalize();

        m_dir = transform.forward;

    }
}
