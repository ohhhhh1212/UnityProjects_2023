using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCnt : MonoBehaviour
{
    [SerializeField] GameObject[] Heals = null;
    [SerializeField] AudioSource HealSound = null;
    [SerializeField] FXTest Bomb = null;

    void Heal()
    {
        HealSound.Play();
        for (int i = 0; i < Heals.Length; i++)
        {
            Heals[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Heal();

        if (Input.GetKeyDown(KeyCode.G))
            Bomb.PlayEffect();
    }


}
