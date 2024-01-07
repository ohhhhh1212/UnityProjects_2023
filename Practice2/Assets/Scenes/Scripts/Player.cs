using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float m_Speed = 5f;

    void Update()
    {
        Move();
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float xDir = x * Time.deltaTime * m_Speed;
        float zDir = y * Time.deltaTime * m_Speed;

        transform.Translate(xDir, zDir, 0f);
    }
}
