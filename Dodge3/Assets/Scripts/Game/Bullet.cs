using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float m_bulletSpeed = 4f;
    Vector3 dir;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * m_bulletSpeed, Space.World);
    }

    public void Init(Transform target)
    {
        transform.LookAt(target);

        dir = target.position - transform.position;
        dir.Normalize();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
            Destroy(gameObject);
        else if(collision.transform.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
