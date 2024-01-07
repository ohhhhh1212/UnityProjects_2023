using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] float bgSpeed = 1f;
    [SerializeField] Transform[] Bgs = null;
    float size = 0f;
    float leftPosX;
    Vector3 rightPos;
    int frontBGNum = 0;

    private void Update()
    {
        for (int i = 0; i < Bgs.Length; i++)
        {
            Bgs[i].Translate(Vector2.left * bgSpeed * Time.deltaTime);
        }

        Check();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        size = Bgs[1].position.x - Bgs[0].position.x;
        rightPos = Bgs[Bgs.Length - 1].position;
        leftPosX = Bgs[0].position.x - size;
    }

    void Check()
    {
        float f = Bgs[frontBGNum].position.x + size / 2;
        if (f <= leftPosX)
        {
            Bgs[frontBGNum].position = rightPos;
            frontBGNum = (frontBGNum + 1) % Bgs.Length;
        }
    }
}
