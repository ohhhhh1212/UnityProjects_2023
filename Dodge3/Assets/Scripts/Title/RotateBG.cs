using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBG : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 5f * Time.deltaTime);
    }
}
