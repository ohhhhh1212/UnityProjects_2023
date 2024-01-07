using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXTest : MonoBehaviour
{
    [SerializeField] GameObject[] particles = null;
    float min = 0.1f;
    float max = 0.4f;

    IEnumerator Co_Effect()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(true);
            particles[i].GetComponent<AudioSource>().Play();

            float delay = Random.Range(min, max);
            yield return new WaitForSeconds(delay);
        }
    }

    public void PlayEffect()
    {
        StartCoroutine(Co_Effect());
    }

    public void StopEffect()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
            particles[i].GetComponent<AudioSource>().Stop();
            StopAllCoroutines();
        }
    }

}
