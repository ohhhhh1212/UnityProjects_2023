using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public void Init(float t)
    {
        Destroy(gameObject, t);
    }
}
