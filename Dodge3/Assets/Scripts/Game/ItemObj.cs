using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public int m_type = 0;
    public int m_value = 0;

    public void Init(int id, int value)
    {
        m_type = id;
        m_value = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            Destroy(gameObject);
    }
}
