using UnityEngine;

public class Player : MonoBehaviour
{
    float m_speed = 5f;
    [SerializeField] ParticleSystem m_bomb = null;
    [SerializeField] AudioSource m_bombSound = null;
    [SerializeField] GamingUI m_GameingUI = null;
    [SerializeField] GameUI m_GameUI = null;
    int m_maxHp = 0;
    bool m_isSFX = false;

    private void Update()
    {
        if (!GameMgr.Inst.battleFSM.IsGameState())
            return;

        Move();
    }

    public void Init()
    {
        m_maxHp = GameMgr.Inst.gameInfo.m_PlayerHp;
        transform.position = new Vector3(0f, 1.8f, -3f);
        m_isSFX = GameMgr.Inst.isSFX;
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z);
        dir.Normalize();

        transform.Translate(dir * Time.deltaTime * m_speed, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            GameMgr.Inst.SetBonusScore(-2);
            m_bomb.gameObject.SetActive(true);
            m_bomb.Play();
            MinusHp();
            m_GameingUI.SetHP();

            if(m_isSFX)
                m_bombSound.Play();
        }

        if (collision.transform.CompareTag("Item"))
        {
            GameMgr.Inst.SetBonusScore(3);

            int id = collision.transform.GetComponent<ItemObj>().m_type;

            if (id == 1)
            {
                // Èú
                PlusHp(collision.transform);
                m_GameUI.StartHeal();
                m_GameingUI.SetHP();
            }
            else if (id == 2)
            {
                // ÆøÅº
                m_GameUI.StartBomb(collision.transform.GetComponent<ItemObj>().m_value);
            }

            Destroy(collision.gameObject);
        }
    }


    void PlusHp(Transform trans)
    {
        int value = trans.GetComponent<ItemObj>().m_value;
        GameMgr.Inst.gameInfo.m_PlayerHp += value;

        if (GameMgr.Inst.gameInfo.m_PlayerHp > m_maxHp)
        {
            GameMgr.Inst.gameInfo.m_PlayerHp = m_maxHp;
        }
    }

    void MinusHp()
    {
        GameMgr.Inst.gameInfo.m_PlayerHp -= GameMgr.Inst.gameInfo.m_BulletAttack;

        if (GameMgr.Inst.gameInfo.m_PlayerHp <= 0)
        {
            GameMgr.Inst.gameInfo.m_PlayerHp = 0;
            GameMgr.Inst.battleFSM.SetResultState();
        }
    }
}
