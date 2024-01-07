using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    [SerializeField] Transform m_target = null;
    float m_bulletSpeed = 4.0f;
    Vector3 m_dir = Vector3.zero;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (m_target == null)
            return;

        transform.Translate(m_dir * m_bulletSpeed * Time.deltaTime, Space.World);
    }

    public void Init(Transform target)
    {
        m_target = target;
        m_dir = target.position - transform.position;
        m_dir.Normalize();

        transform.LookAt(m_target);
    }

}
