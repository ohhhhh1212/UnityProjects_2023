using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] Animator m_animator = null;
    SpriteRenderer m_sprite = null;
    bool isJump = false;

    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Moving();

        if (Input.GetMouseButtonDown(0))
            m_animator.SetTrigger("attack");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump)
                return;

            Vector3 vPos = transform.localPosition;
            vPos.y += 3f;
            transform.localPosition = vPos;
            m_animator.SetTrigger("jump");

            isJump = true;
        }
    }

    void Moving()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x < 0)
            m_sprite.flipX = true;
        else if(x > 0)
            m_sprite.flipX = false;

        Vector3 v3 = new Vector3(x, 0f, z);
        v3.Normalize();

        transform.Translate(v3 * 3f * Time.deltaTime);

        if (x == 0 && z == 0)
            m_animator.SetBool("walk", false);
        else
            m_animator.SetBool("walk", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
    }
}
