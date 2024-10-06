using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : Singleton<BulletInfo>
{
    public float BulletSpeed = 10;

    public int GetRandomValue()
    {
        // 0부터 99까지의 정수를 무작위로 생성 (0~99)
        int randomValue = Random.Range(0, 100);

        // 0: 0 반환 (1% 확률)
        if (randomValue < 1)
        {
            return 0;
        }
        // 1~60: 1 반환 (60% 확률)
        else if (randomValue < 61)
        {
            return 1;
        }
        // 61~99: 2 반환 (39% 확률)
        else
        {
            return 2;
        }
    }
}
